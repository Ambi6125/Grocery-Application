using EasyTools.Validation;
using RobertHeijn_Desktop.Controls;
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
    public partial class CategoryForm : Form
    {
        private Category? draft = null;

        private readonly Homescreen origin;
        private readonly RootManager rootManager;
        public CategoryForm(RootManager manager, Homescreen source)
        {
            InitializeComponent();
            origin = source;
            rootManager = manager;
        }

        private bool IsEdited => draft is not null ? draft.Name == tbName.Text : false;

        private void OnLoad(object sender, EventArgs e) //Load in category form
        {
            pnlControlContainer.Controls.Add(new CategoryFlowBox(rootManager.CategoryManager));
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                origin.Show();
            }
        }

        private void OnLeaveNameBox(object sender, EventArgs e)
        {
            var selection = ((CategoryFlowBox)pnlControlContainer.Controls.Single()).SelectedCategory;
            if(selection is null || tbName.Text != selection.Name)
            {
                draft = null;
                return;
            }
            else if(tbName.Text == selection.Name)
            {
                draft = selection;
            }
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            var categoryManager = rootManager.CategoryManager;

            Category newCategory;

            Func<Category, IValidationResponse> databaseInteraction;

            if(draft is not null) //If draft has a value, it was imported
            {
                databaseInteraction = categoryManager.Update;
                newCategory = draft;
            }
            else
            {
                if (tbName.Text.IsNullOrWhiteSpace())
                {
                    MessageBox.Show("Please input a name for the new category");
                    return;
                }
                databaseInteraction = categoryManager.CreateNew;
                var userSelectedCategory = ((CategoryFlowBox)pnlControlContainer.Controls.Single()).SelectedCategory;
                if (userSelectedCategory is null)
                {
                    MessageBox.Show("Please select a parent category");
                }

                newCategory = new Category(tbName.Text, userSelectedCategory);
            }

            var response = databaseInteraction(newCategory);

            MessageBox.Show(response.Message);
        }

        private void OnImportClick(object sender, EventArgs e)
        {
            draft = ((CategoryFlowBox)pnlControlContainer.Controls.Single()).SelectedCategory;
        }

        private void OnParentSelectClick(object sender, EventArgs e)
        {
            draft = null;
            lblSelection.Text = ((CategoryFlowBox)pnlControlContainer.Controls.Single()).SelectedCategory.Name;
        }
    }
}
