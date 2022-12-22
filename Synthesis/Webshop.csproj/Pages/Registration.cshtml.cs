using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SynthesisDataLayer.Accounts;
using SynthesisEntities.Accounts;
using SynthesisLogic.Accounts;

namespace Webshop.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public string? Username { get; set; }
        [BindProperty]
        public string? Password { get; set; }
        [BindProperty]
        public string? ConfirmPassword { get; set; }
        [BindProperty]
        public string? Email { get; set; }
        [BindProperty]
        public string? ShippingAddress { get; set; }
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        private bool AllInputFilled()
        {
            string?[] inputs = { Username, Password, ConfirmPassword, Email };
            return inputs.All(x => !string.IsNullOrWhiteSpace(x));
        }

        public void OnPost()
        {
            if (!AllInputFilled())
            {
                ErrorMessage = "Not all inputs are filled in.";
                return;
            }
            else if(Password != ConfirmPassword)
            {
                ErrorMessage = "Passwords do not match.";
                return;
            }
            ErrorMessage = string.Empty;
            Account newAccount = new CustomerAccount(Username, Password, Email, ShippingAddress);

            AccountManager am = new AccountManager(new DBAccount());

            var response = am.RegisterAccount(newAccount);


            if (response.Success)
            {
                HttpContext.Response.Redirect("/Success?action=registration");
            }
            else
            {
                ErrorMessage = response.Message;
            }
        }
    }
}
