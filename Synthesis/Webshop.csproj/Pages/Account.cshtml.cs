using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class AccountModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Response.Redirect("/Success?action=logout");
        }
    }
}
