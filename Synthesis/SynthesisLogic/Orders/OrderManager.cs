using SynthesisEntities.Accounts;
using SynthesisEntities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisLogic.Orders
{
    public class OrderManager
    {
        private List<Order> orders;


        public OrderManager()
        {
            orders = new List<Order>();
        }


        public IReadOnlyCollection<Order> GetFromUser(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
