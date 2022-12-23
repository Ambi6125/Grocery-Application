using EasyTools.MySqlDatabaseTools;
using SynthesisEntities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisDataLayer.Products
{
    public interface IProductRepo
    {
        void Add(Product p);

        /// <summary>
        /// Gets data from products whose name matches the input string.
        /// Due to circular dependency, the products cannot be constructed on this level and
        /// the data must be used elsewhere to create objects.
        /// </summary>
        IReadOnlyCollection<IReadOnlyParameterValueCollection> GetByName(string name);
    }
}
