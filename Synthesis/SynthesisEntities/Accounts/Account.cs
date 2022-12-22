using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyTools.MySqlDatabaseTools;
using SynthesisEntities.Passwords;
using System.Text.RegularExpressions;

namespace SynthesisEntities.Accounts
{
    public abstract class Account : IDataProvider
    {
        private readonly int? _id;
        private string username;
        private string salt;
        private string password;
        private string email;
        public string Username
        {
            get => username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else if(value.Length < 4)
                {
                    throw new ArgumentException("Username must be at least 4 characters long.");
                }
                username = value;
            }
        }
        public string Email
        {
            get => email;
            set
            {
                if (!Regex.IsMatch(value, @"^[A-z 0-9]+\.?[A-z 0-9]+@[a-z]+\.\w{2,3}$"))
                {
                    throw new ArgumentException("Not a valid email address");
                }
                email = value;
            }
        }

        public int ID => _id.HasValue ? _id.Value : throw new NullReferenceException();

        /// <summary>
        /// Create a NEW account which has not been registered
        /// </summary>
        public Account(string username, string password, string email)
        {
            _id = null;
            this.username = username;
            salt = PasswordHelper.GenerateSalt(45);
            HashAlgorithm algorithm = PasswordHelper.DefaultHash;
            this.password = algorithm(salt, password);
            this.email = email;
        }

        public Account(int id, string username, string salt, string password, string email)
        {
            _id = id;
            this.username = username;
            this.salt = salt;
            this.password = password;
            this.email = email;
        }

        public IParameterValueCollection GetParameterArgs()
        {
            var result = new ParameterValueCollection
            {
                { "id", _id },
                { "username", username },
                { "salt", salt },
                { "password", password },
                { "email", email }
            };

            //if(this is CustomerAccount ca)
            //{
            //    result.Add("address", ca.ShippingAddress);
            //}
            //else if(this is EmployeeAccount ea)
            //{
            //    result.Add("birthday", ea.Birthday);
            //}

            return result;
        }

        public bool PasswordMatches(string password)
        {
            return this.password == PasswordHelper.DefaultHash(salt, password);
        }

        public bool PasswordMatches(string password, HashAlgorithm hash)
        {
            return this.password == hash(salt, password);
        }
    }
}
