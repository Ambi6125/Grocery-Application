using EasyTools.Validation;
using RobertHeijn_Desktop.Controls;
using SynthesisEntities.Products;
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
    public partial class ProductsForm : Form
    {
        private readonly Homescreen origin;
        private readonly RootManager managers;
        public ProductsForm(RootManager managers, Homescreen source)
        {
            InitializeComponent();
            origin = source;
            this.managers = managers;
        }

        private CategoryFlowBox CategoryBox => ((CategoryFlowBox)pnlFlowBoxHolder.Controls.Single());
        private CategoryPicker ActivePicker => throw new NotImplementedException();

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                origin.Show();
            }
        }

        private void OnCategoryChoiceChange(object sender, EventArgs e)
        {

        }

        private void SpawnControls()
        {
            CategoryFlowBox controlBox = new CategoryFlowBox(managers.CategoryManager);
            pnlFlowBoxHolder.Controls.Add(controlBox);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SpawnControls();
            
        }

        private void RefreshProductsDisplay(object sender, EventArgs e)
        {

        }

        private ValidationResponse ValidateInput()
        {
            if (tbName.Text.IsNullOrWhiteSpace())
            {
                return new(false, "No name specified.");
            }


            return new(true, string.Empty);
        }
        private void OnCreateClick(object sender, EventArgs e)
        {
            var validationResult = ValidateInput();

            if (!validationResult.Success)
            {
                MessageBox.Show(validationResult.Message);
                return;
            }

            var selectedCategory = CategoryBox.SelectedCategory;
            if(selectedCategory == null)
            {
                MessageBox.Show("Please select a category this product should belong in.");
                return;
            }
            Product newProduct = new Product(tbName.Text, (double)nmudPrice.Value, selectedCategory);


            string message;

            try
            {
                managers.ProductManager.Add(newProduct);
                message = "Succesfully added.";
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                message = ex.Message;
            }

            MessageBox.Show(message); 
        }
    }
}
