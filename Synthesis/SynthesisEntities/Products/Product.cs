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
        private int? _id;
        private string name;



        public bool Equals(Product? other)
        {
            return _id == other?._id;
        }

        public IParameterValueCollection GetParameterArgs()
        {
            throw new NotImplementedException();
        }
    }
}
