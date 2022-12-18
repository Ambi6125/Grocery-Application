using EasyTools.Validation;
using SynthesisEntities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisDataLayer.Accounts
{
    public interface IAccountRepo
    {
        IValidationResponse Register(Account account);

        IValidationResponse Delete(Account account);

        IValidationResponse Update(Account account);

        Account? MatchUsername(string username);
    }
}
