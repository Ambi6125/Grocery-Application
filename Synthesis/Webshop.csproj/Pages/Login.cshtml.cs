using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty, Required(ErrorMessage = "Please enter a username")]
        public string? TextboxUsername { get; set; }
        [BindProperty, Required(ErrorMessage = "Please enter a password")]
        public string? TextboxPassword { get; set; }
        public void OnGet()
        {
        }
    }
}
