using RobertHeijn_Desktop.Forms;
using SynthesisDataLayer.Accounts;
using SynthesisDataLayer.Categories;
using SynthesisDataLayer.Products;
using SynthesisEntities.Accounts;
using SynthesisLogic;
using SynthesisLogic.Accounts;
using SynthesisLogic.Categories;
using SynthesisLogic.Products;

namespace RobertHeijn_Desktop
{
    public partial class LoginForm : Form
    {
        private RootManager managers;
        public LoginForm()
        {
            InitializeComponent();
            CategoryManager cm = new CategoryManager(new DBCategories());
            managers = new RootManager(
                new AccountManager(new DBAccount()),
                cm,
                new ProductManager(new DBProducts(), cm) 
                );
        }

        private void OnLoginClick(object sender, EventArgs e)
        {
            AccountManager am = managers.AccountManager;

            Account? receivedData = null;

            try
            {
                receivedData = am.GetByUsernameExact(tbUsername.Text);
            }
            catch (InvalidDataException)
            {
                MessageBox.Show("There appear to be multiple accounts with this username.\nContact your supervisor.");
                return;
            }
            catch (FormatException)
            {
                MessageBox.Show("Something went wrong processing account data.");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unknown error occurre.\nPlease contact support.\n {ex}", "Non-fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(receivedData is null)
            {
                MessageBox.Show("No account found.");
                return;
            }
            else if(receivedData is not EmployeeAccount)
            {
                MessageBox.Show("You do not have permissions to log in here.");
                return;
            }


            if (receivedData.PasswordMatches(tbPassword.Text))
            {
                SessionSimulator.LoggedUser = receivedData;
                Homescreen newScreen = new Homescreen(managers, this);
                newScreen.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Incorrect password.");
            }
        }

        private void OnRegisterClick(object sender, EventArgs e)
        {
            new RegistrationForm(managers, this).Show();
            Hide();
        }
    }
}