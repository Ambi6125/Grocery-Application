using EasyTools.MySqlDatabaseTools;
using SynthesisEntities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisEntities.Orders
{
    public class Order : IDataProvider
    {
        private int? id;
        private Account placer;
        private IEnumerable<OrderItem> items;

        public double TotalPrice
        {
            get
            {
                double current = 0;
                foreach(OrderItem orderItem in items)
                {
                    //TODO: Implement discounts
                    current += orderItem.Product.Price * orderItem.Quantity;
                }
                return current;
            }
        }

        public Order(Account customer, IEnumerable<OrderItem> products)
        {
            id = null;
            placer = customer;
            items = products;
        }

        public IParameterValueCollection GetParameterArgs()
        {
            throw new NotImplementedException();
        }
    }
}
