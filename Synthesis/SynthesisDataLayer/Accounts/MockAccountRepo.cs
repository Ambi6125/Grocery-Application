using EasyTools.Validation;
using SynthesisEntities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisDataLayer.Accounts
{
    public class MockAccountRepo : IAccountRepo
    {
        public IValidationResponse Delete(Account account)
        {
            return new ValidationResponse(true, "ALways returns true");
        }

        public List<Account>? GetAll()
        {
            return null;
        }

        public Account? MatchUsername(string username)
        {
            return null;
        }

        public IValidationResponse Register(Account account)
        {
            return new ValidationResponse(true, "ALways returns true");
        }

        public IValidationResponse Update(Account account)
        {
            return new ValidationResponse(true, "ALways returns true");
        }
    }
}
