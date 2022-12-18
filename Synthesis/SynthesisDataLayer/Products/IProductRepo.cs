using EasyTools.Validation;
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
        /// <summary>
        /// Gets a product matching the name as primary key.
        /// </summary>
        /// <param name="name">The primary key</param>
        /// <returns></returns>
        Product GetByName(string name);

        /// <summary>
        /// Searches for all products containing the specified string.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IReadOnlyCollection<Product> SearchByName(string name);

        /// <summary>
        /// Registers a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>A bool indicating whether it was successful, and a message.
        /// If working with a database, returns the newly added ID as well.</returns>
        IValidationResponse Create(Product product);
        IValidationResponse Update(Product product);
        IValidationResponse Delete(Product product);
    }
}
