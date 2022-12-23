using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Pages
{
    public class SearchModel : PageModel
    {
        [BindProperty, Required( ErrorMessage = "Please type a term to search by.")]
        public string? SearchInput { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                HttpContext.Response.Redirect($"/SearchResults?term={SearchInput}");
            }
        }
    }
}
