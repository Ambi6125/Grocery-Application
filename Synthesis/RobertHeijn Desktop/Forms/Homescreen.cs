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
    public partial class Homescreen : Form
    { 
        private readonly LoginForm origin;
        private readonly RootManager managers;
        public Homescreen(RootManager managers, LoginForm source)
        {
            InitializeComponent();
            this.managers = managers;
            origin = source;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Text = SessionSimulator.LoggedUser?.Username ?? "Home";
        }

        private void OnCategoryButtonClick(object sender, EventArgs e)
        {
            CategoryForm cf = new CategoryForm(managers, this);
            cf.Show();
            Hide();
        }

        private void OnProductsButtonClick(object sender, EventArgs e)
        {
            ProductsForm cf = new ProductsForm(managers, this);
            cf.Show();
            Hide();
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
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
