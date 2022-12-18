using EasyTools.MySqlDatabaseTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisEntities.Products
{
    public class Product : IEquatable<Product>, IDataProvider
    {
        private string name;
        private double price;

        public string Name => name;

        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public double Price
        {
            get => price;
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Price cannot be below 0");
                }
                price = value;
            }
        }

        public bool Equals(Product? other)
        {
            return name == other.name && price == other.price;
        }

        public IParameterValueCollection GetParameterArgs()
        {
            return new ParameterValueCollection()
            {
                { "name", name },
                { "price", price }
            };
        }
    }
}
