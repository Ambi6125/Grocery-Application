using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyTools.Validation;
using SynthesisDataLayer.Accounts;
using SynthesisEntities.Accounts;

namespace SynthesisLogic.Accounts
{
    public class AccountManager
    {
        private readonly IAccountRepo repo;

        private readonly List<Account> accounts;

        /// <summary>
        /// Initializes a new instance of the AccountManager class.
        /// </summary>
        /// <param name="repository">A repository to draw data from.</param>
        public AccountManager(IAccountRepo repository)
        {
            repo = repository;
            accounts = new List<Account>();
        }

        /// <summary>
        /// Registers a new account.
        /// </summary>
        public IValidationResponse RegisterAccount(Account account)
        {
            var dbResponse = repo.Register(account);
            if(dbResponse.Success)
                accounts.Add(account);
            return dbResponse;
        }

        /// <summary>
        /// Gets an account whose username is an exact match.
        /// If such an object has memory allocated to it, that is returned instead.
        /// </summary>
        public Account? GetByUsernameExact(string username)
        {
            var foundAccount = accounts.FirstOrDefault(a => a.Username == username);
            if(foundAccount is not null)
            {
                return foundAccount;
            }

            var result = repo.MatchUsername(username);
            if(result is not null)
            {
                accounts.Add(result);
            }
            return result;
        }
    }
}
