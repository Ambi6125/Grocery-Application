using EasyTools.Validation;
using SynthesisEntities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using EasyTools.MySqlDatabaseTools;

namespace SynthesisDataLayer.Products
{
    public sealed class DBProducts : IProductRepo
    {
        private IDatabaseCommunicator database = new MySqlCommunicator(Metadata.HERADB);
        public IValidationResponse Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IValidationResponse Create(Product product)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Product> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public IValidationResponse Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
