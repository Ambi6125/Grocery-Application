using SynthesisLogic.Accounts;
using SynthesisLogic.Categories;
using SynthesisLogic.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisLogic
{
    public class RootManager
    {
        public AccountManager AccountManager { get; }
        public CategoryManager CategoryManager { get; }

        public ProductManager ProductManager { get; }
        public RootManager(AccountManager accountManager, CategoryManager categoryManager, ProductManager productManager)
        {
            AccountManager = accountManager;
            CategoryManager = categoryManager;
            ProductManager = productManager;
        }
    }
}
