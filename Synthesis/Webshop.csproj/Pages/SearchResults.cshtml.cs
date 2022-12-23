using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SynthesisDataLayer.Categories;
using SynthesisDataLayer.Products;
using SynthesisEntities.Categories;
using SynthesisEntities.Products;
using SynthesisLogic.Categories;
using SynthesisLogic.Products;

namespace Webshop.Pages
{
    public class SearchResultsModel : PageModel
    {
        public IReadOnlyCollection<Product> ResultProducts { get; set; }
        public void OnGet(string? term)
        {
            CategoryManager categoryManager = new CategoryManager(new DBCategories());
            ProductManager productManager = new ProductManager(new DBProducts(), categoryManager);

            ResultProducts = productManager.SearchByName(term);
        }

        public void OnPostOrder(Product product)
        {
            HttpContext.Response.Redirect($"/AddOrderItem?prod={product.Name}");
        }
    }
}
