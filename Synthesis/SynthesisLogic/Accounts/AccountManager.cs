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
        private IAccountRepo repo;

        private List<Account> accounts;

        public AccountManager(IAccountRepo repository)
        {
            repo = repository;

        }

        public IValidationResponse RegisterAccount(Account account)
        {
            return repo.Register(account);
        }

        public Account? GetByUsernameExact(string username)
        {
            return repo.MatchUsername(username);
        }
    }
}
