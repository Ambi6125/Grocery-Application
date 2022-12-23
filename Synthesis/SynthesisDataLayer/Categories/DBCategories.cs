using EasyTools.MySqlDatabaseTools;
using EasyTools.MySqlDatabaseTools.Queries;
using EasyTools.MySqlDatabaseTools.Tables;
using EasyTools.Validation;
using MySql.Data.MySqlClient;
using SynthesisEntities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisDataLayer.Categories
{
    public sealed class DBCategories : ICategoryRepo
    {
        private readonly MySqlTable categoriesTable = new MySqlTable("sy_categories");
        private readonly MySqlCommunicator database = new MySqlCommunicator(Metadata.HERADB);
        /// <summary>
        /// Retrieves all top-level categories from the database.
        /// </summary>
        public IReadOnlyCollection<Category> ReadTopLevel()
        {
            List<Category> categories = new List<Category>();
            string query = "SELECT id, name FROM sy_categories where parentId is null";
            using (MySqlConnection conn = new MySqlConnection(Metadata.HERADB))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string name = reader.GetString("name");

                            Category c = new Category(id, name, null);
                            categories.Add(c);
                        }
                    }
                    finally
                    {
                        if(conn.State is not System.Data.ConnectionState.Closed)
                            conn.Close();
                        conn.Dispose();
                    }
                }
            }
            return categories;
        }

        public IReadOnlyCollection<Category> NextGeneration(Category parentCategory)
        {
            string query = "SELECT * FROM sy_categories WHERE parentId = @inputParentId";
            List<Category> children = new List<Category>();

            using (MySqlConnection conn = new MySqlConnection(Metadata.HERADB))
            {
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("inputParentId", parentCategory.ID);
                    try
                    {

                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string name = reader.GetString("name");

                            var childCategory = new Category(id, name, parentCategory);
                            children.Add(childCategory);
                        }
                        conn.Close();
                    }
                    finally
                    {
                        if (conn.State != System.Data.ConnectionState.Closed)
                            conn.Close();
                        conn.Dispose();
                    }
                }
            }
            return children;
        }

        public IValidationResponse Insert(Category category)
        {
            InsertQuery query = new InsertQuery(categoriesTable, category);
            return database.Insert(query);
        }

        public IValidationResponse Update(Category category)
        {
            MySqlCondition condition = new MySqlCondition("id", category.ID, Strictness.MustMatchExactly);
            UpdateQuery query = new UpdateQuery(categoriesTable, category, condition);

            return database.Update(query);
        }

        public Category? GetByPrimaryKey(int id)
        {
            var condition = new MySqlCondition("id", id, Strictness.MustMatchExactly);
            var query = new SelectQuery(categoriesTable, "*", condition);
            var response = database.Select(query);

            var row = response.Single();

            int resultId = row.GetValueAs<int>("id");
            string resultName = row.GetValueAs<string>("name");


            //Determine whether a parent needs to be constructed
            Category? resultParent;
            object parentId = row["parentId"];
            if(parentId is (null or DBNull))
            {
                resultParent = null;
            }
            else
            {
                resultParent = GetByPrimaryKey((int)parentId);
            }


            return new Category(resultId, resultName, resultParent);
        }
    }
}
