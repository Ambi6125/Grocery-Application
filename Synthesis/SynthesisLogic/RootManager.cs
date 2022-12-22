using SynthesisLogic.Accounts;
using SynthesisLogic.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisLogic
{
    public class RootManager
    {
        public AccountManager AccountManager { get; set; }
        public CategoryManager CategoryManager { get; set; }

        public RootManager()
        {

        }
        public RootManager(AccountManager accountManager, CategoryManager categoryManager)
        {
            AccountManager = accountManager;
            CategoryManager = categoryManager;
        }
    }
}
