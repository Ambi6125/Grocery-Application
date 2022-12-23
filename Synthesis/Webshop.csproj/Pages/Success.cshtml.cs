using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class SuccessModel : PageModel
    {
        public string? Message { get; set; }
        public void OnGet(string action)
        {
            switch (action.ToLower())
            {
                case "registration":
                    Message = "Registration complete! You can now log in.";
                    break;
                case "login":
                    Message = $"You are now logged in, {HttpContext.Session.GetString("Username")}";
                    break;
                case "logout":
                    Message = "You are now logged out";
                    break;
                case "itemadded":
                    Message = "Succesfully added item.";
                    break;
            }
        }
    }
}
