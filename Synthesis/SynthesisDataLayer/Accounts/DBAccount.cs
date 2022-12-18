using EasyTools.Validation;
using SynthesisEntities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using EasyTools.MySqlDatabaseTools;
using EasyTools.MySqlDatabaseTools.Queries;
using EasyTools.MySqlDatabaseTools.Tables;

namespace SynthesisDataLayer.Accounts
{
    internal enum DBAccountType { Customer = 0, Employee = 1 }
    public sealed class DBAccount : IAccountRepo
    {
        private readonly MySqlTable mainTable = new MySqlTable("sy_accounts");
        private readonly MySqlTable customerTable = new MySqlTable("sy_customerAccs");
        private readonly MySqlTable employeeTable = new MySqlTable("sy_empAccs");
        private readonly IDatabaseCommunicator db = new MySqlCommunicator(Metadata.HERADB);

        private DBAccountType DetermineType(IReadOnlyParameterValueCollection values)
        {
            if(values["address"] is not DBNull)
            {
                return DBAccountType.Customer;
            }
            else if(values["birthday"] is not DBNull)
            {
                return DBAccountType.Employee;
            }
            else
            {
                throw new ArgumentException("The account type cannot be derived from the provided dataset.\nIs thedataset invalid?");
            }
        }

        private MySqlTable Customers => mainTable.Join(Join.Inner, "sy_customerAccs", "sy_accounts.id = sy_customerAccs.id");

        private static int GetRecentID()
        {
            string query = "SELECT id FROM sy_accounts ORDER BY id desc LIMIT 1";
            using (MySqlConnection conn = new MySqlConnection(Metadata.HERADB))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        object response = cmd.ExecuteScalar();
                        return (int)response;
                    }
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                }
            }
        }
        private IValidationResponse AddCustomerAccount(CustomerAccount account)
        {
            int newestID = GetRecentID();
            string address = account.ShippingAddress;

            using(MySqlConnection conn = new MySqlConnection(Metadata.HERADB))
            {
                string query = "INSERT INTO sy_customerAccs VALUES (@id, @address)";

                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("id", newestID);
                        cmd.Parameters.AddWithValue("address", address);

                        conn.Open();

                        cmd.ExecuteNonQuery();
                    }

                    return new InsertValidationResponse(true, "Successfully added", newestID);
                }
                catch (MySqlException)
                {
                    return new ValidationResponse(false, "Could not add account specifics.");
                }
                finally
                {
                    if(conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                    conn.Dispose();
                }
            }
        }
        private IValidationResponse AddEmployeeAccount(EmployeeAccount account)
        {
            int newestID = GetRecentID();

            var birthday = account.Birthday;

            string query = "INSERT INTO sy_empAccs VALUES (@id, @bd)";
            using(MySqlConnection conn = new MySqlConnection(Metadata.HERADB))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("id", newestID);
                        cmd.Parameters.AddWithValue("bd", birthday);

                        conn.Open();

                        cmd.ExecuteNonQuery();

                        return new InsertValidationResponse(true, "Succesfully added.", newestID);
                    }
                }
                catch (MySqlException)
                {
                    return new ValidationResponse(false, "Unable to add specifics.");
                }
                finally
                {
                    if(conn.State != System.Data.ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                }
            }
        }
        public IValidationResponse Register(Account account)
        {
            string query = "INSERT INTO" +
                " sy_accounts" +
                " VALUES (@id, @username, @salt, @password, @email)";

            using(MySqlConnection conn = new MySqlConnection(Metadata.HERADB))
            {
                try
                {

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        foreach (var dataPair in account.GetParameterArgs())
                        {
                            cmd.Parameters.AddWithValue(dataPair.ParameterName, dataPair.Value);
                        }

                        cmd.ExecuteNonQuery();


                        if (account is CustomerAccount ca)
                        {
                            var specificationResponse = AddCustomerAccount(ca);
                            if(specificationResponse.Success)
                                return specificationResponse;
                            else
                            {
                                return new NestedValidationResponse(false, "Not all account data could be added.", specificationResponse);
                            }
                        }
                        else if (account is EmployeeAccount ea)
                        {
                            return AddEmployeeAccount(ea);
                        }
                    }
                }
                catch (MySqlException e)
                {

                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                    conn.Dispose();
                }
            }
            throw new ArgumentException("Unknown account type.");
        }
        public IValidationResponse Delete(Account account)
        {
            DeleteQuery query1;

            if(account is CustomerAccount)
            {
                query1 = new DeleteQuery(customerTable, "id", account);
            }
            else
            {
                query1 = new DeleteQuery(employeeTable, "id", account);
            }

            var firstResponse = db.Delete(query1);

            DeleteQuery query2 = new DeleteQuery(mainTable, "id", account);

            var secondResponse = db.Delete(query2);

            return new NestedValidationResponse(secondResponse.Success, secondResponse.Message, firstResponse);
        }

        public IValidationResponse Update(Account account)
        {
            MySqlTable target;
            if(account is EmployeeAccount)
            {
                target = employeeTable;
            }
            else
            {
                target = customerTable;
            }
            MySqlCondition idCondition = new MySqlCondition("id", account.ID, Strictness.MustMatchExactly);
            UpdateQuery query = new UpdateQuery(target, account, idCondition);

            var firstResponse = db.Update(query);

            target = mainTable;

            var secondResponse = db.Update(query);

            return new NestedValidationResponse(secondResponse.Success, secondResponse.Message, firstResponse);
        }

        public Account? MatchUsername(string username)
        {
            MySqlTable table = mainTable
                .Join(Join.Left, "sy_customerAccs", "sy_accounts.id = sy_customerAccs.id")
                .Join(Join.Left, "sy_empAccs", "sy_accounts.id = sy_empAccs.id");

            MySqlCondition condition = new MySqlCondition("username", username, Strictness.MustMatchExactly);
            SelectQuery query = new SelectQuery(table, "sy_accounts.*, sy_customerAccs.address, sy_empaccs.birthday", condition);
            var dbResponse = db.Select(query);

            if (dbResponse.Count > 1)
                throw new InvalidDataException("Unexpected result: query returned more than 1 row.");
            var dataRow = dbResponse.FirstOrDefault();
            if (dataRow is null)
                return null;


            //Read common data
            int id = dataRow.GetValueAs<int>("id");
            string salt = dataRow.GetValueAs<string>("salt");
            string password = dataRow.GetValueAs<string>("Password");
            string email = dataRow.GetValueAs<string>("email");
            DBAccountType type = DetermineType(dataRow);
            Account result;

            //Assign a different value to the result account
            switch (type)
            {
                case DBAccountType.Customer:
                    string address = dataRow.GetValueAs<string>("address");
                    result = new CustomerAccount(id, username, salt, password, email, address);
                    break;
                case DBAccountType.Employee:
                    DateTime birthDay = dataRow.GetValueAs<DateTime>("birthday").Date;
                    result = new EmployeeAccount(id, username, salt, password, email, birthDay);
                    break;
                default:
                    throw new FormatException("Unrecognized account");
            }

            return result;
        }
    }
}
