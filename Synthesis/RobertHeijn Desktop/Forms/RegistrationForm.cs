using EasyTools.Validation;
using SynthesisEntities.Accounts;
using SynthesisEntities.Categories;
using SynthesisLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobertHeijn_Desktop.Forms
{
    public partial class RegistrationForm : Form
    {
        private readonly LoginForm origin;
        private readonly RootManager rootManager;
        public RegistrationForm(RootManager managers, LoginForm source)
        {
            InitializeComponent();
            origin = source;
            rootManager = managers;
        }

        private ValidationResponse ValidateInput() 
        {
            if (tbUsername.Text.IsNullOrWhiteSpace())
                return new(false, "No username given,");
            else if (tbPassword.Text.IsNullOrWhiteSpace())
                return new(false, "No password given.");
            else if (tbEmail.Text.IsNullOrWhiteSpace())
                return new(false, "No email given.");
            else if (!tbEmail.Text.IsEmail())
                return new(false, "Not a valid email address.");
            else if (DateTime.Today < dtpBirthday.Value.Date)
                return new(false, "Cannot be born in the future.");
            else if (DateTime.Today.AddYears(-18) < dtpBirthday.Value.Date)
                return new(false, "Must be 18 years or older.");

            return new(true, string.Empty);
        }

        private void OnRegister(object sender, EventArgs e)
        {
            var validationData = ValidateInput();
            if (!validationData.Success)
            {
                MessageBox.Show(validationData.Message);
                return;
            }


            var accountManager = rootManager.AccountManager;
            try
            {
                var registeringAccount = new EmployeeAccount(tbUsername.Text, tbPassword.Text, tbEmail.Text, dtpBirthday.Value);
                var response = accountManager.RegisterAccount(registeringAccount);

                MessageBox.Show(response.Message);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Impossible data input. Please change your input.");
            }
        }

        private void OnClose(object sender, FormClosedEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    origin.Show();
                    break;
                case CloseReason.TaskManagerClosing:
                    origin.Close();
                    break;
            }
        }
    }
}
