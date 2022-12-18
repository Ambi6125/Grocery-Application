using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisEntities.Accounts
{
    public class CustomerAccount : Account
    {
        private string address;

        public string ShippingAddress => address;
        public CustomerAccount(string username, string password, string email, string address) : base(username, password, email)
        {
            this.address = address;
        }

        public CustomerAccount(int id, string username, string salt, string password, string email, string address) : base(id, username, salt, password, email)
        {
            this.address = address;
        }
    }
}
