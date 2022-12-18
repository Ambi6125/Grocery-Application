using SynthesisEntities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisEntities.Orders
{
    public class OrderItem
    {
        
        public Product Product { get; }
        public int Quantity { get; set; }

        public OrderItem(Product product)
        {
            Product = product;
            Quantity = 0;
        }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
