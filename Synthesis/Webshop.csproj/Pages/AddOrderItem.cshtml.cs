using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SynthesisEntities.Orders;
using SynthesisLogic.Cart;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Pages
{
    public class AddOrderItemModel : PageModel
    {
        public string? Product { get; set; }

        [BindProperty, Required, Range(1, 99)]
        public int Quantity { get; set; }
        public void OnGet(string? prod)
        {
            Product = prod;
        }

        public void OnPost()
        {
            string? currentUsername = HttpContext.Session.GetString("Username");
            string expectedCookieName = $"{currentUsername}_cart";
            if (Request.Cookies.ContainsKey(expectedCookieName))
            {
                string? cartString = Request.Cookies[expectedCookieName];
                var formattedValues = OrderFormatter.Deformat(cartString).ToList();
                
                formattedValues.Add(new(Product, Quantity));

                string cookieString = OrderFormatter.Format(formattedValues);

                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7)
                };

                Response.Cookies.Append(expectedCookieName, cookieString, options);

                HttpContext.Response.Redirect("/Success?action=itemadded");
            }
            else
            {
                HttpContext.Response.Redirect("/Error");
            }
        }
    }
}
