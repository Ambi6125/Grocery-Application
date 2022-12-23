using EasyTools.MySqlDatabaseTools;
using SynthesisEntities.Categories;
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
        private Category category;
        public string Name => name;
        public Category Category => category;
        public Product(string name, double price, Category category)
        {
            if(category.Parent is null)
            {
                throw new ArgumentException("Products cannot be added to top-level categories.");
            }
            this.name = name;
            this.price = price;
            this.category = category;
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

        public override string ToString()
        {
            return name;
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
                { "price", price },
                { "category", category.ID }
            };
        }
    }
}
