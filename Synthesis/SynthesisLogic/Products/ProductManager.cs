using SynthesisDataLayer.Products;
using SynthesisEntities.Categories;
using SynthesisEntities.Products;
using SynthesisLogic.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisLogic.Products
{
    public class ProductManager
    {
        private readonly IProductRepo _repo;
        private readonly List<Product> products;
        private readonly CategoryManager categoryManager;
        public ProductManager(IProductRepo repo, CategoryManager categorySourceBuilder)
        {
            products = new List<Product>();
            _repo = repo;
            categoryManager = categorySourceBuilder;
        }

        public void Add(Product p)
        {
            _repo.Add(p);
            products.Add(p);
        }
        public IReadOnlyCollection<Product> SearchByName(string name)
        {
            {
                var filteredList = products.Where(p => p.Name.ToLower().Contains(name.ToLower()));
                filteredList.Concat(products.Where(p => p.Category.GetTreeString().ToLower().Contains(name.ToLower())));
                if (filteredList.Any())
                {
                    return filteredList.ToArray();
                }
            }

            var responseDataSet = _repo.GetByName(name);

            List<Product> result = new List<Product>();

            foreach(var dataRow in responseDataSet)
            {
                string resultName = dataRow.GetValueAs<string>("name");
                double price = dataRow.GetValueAs<double>("price");
                Category? parent = categoryManager.GetById((int?)dataRow["parentId"]);

                result.Add(new Product(resultName, price, parent));
            }
            /*TODO: Make database return results if categories match the names.
             * To do this make a method that searches a category by name and then gets its whole tree using GetById();
             */
            products.AddRange(result);
            return result;
        }
    }
}
