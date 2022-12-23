using SynthesisEntities.Categories;
using SynthesisLogic.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobertHeijn_Desktop.Controls
{
    public partial class CategoryPicker : UserControl
    {
        /// <summary>
        /// How deep into the spawning tree this category is nested. The default value is 0.
        /// </summary>
        public int Generation { get; } = default;
        private readonly CategoryManager _categoryManager;
        private Category? parent;

        public ComboBox ComboBox => cbbCategory;

        public Category? Selection
        {
            get
            {
                if(cbbCategory.SelectedItem is not Category) //No selection if no category selected 
                    return null;
                return cbbCategory.SelectedItem as Category;
            }
        }

        public CategoryPicker(CategoryManager manager, Category? parent, int generation)
        {
            InitializeComponent();
            _categoryManager = manager;
            this.parent = parent;
            Generation = generation;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SpawnChildren();
            lblId.Text = $"Step {Generation + 1}";
        }

        /// <summary>
        /// Adds an empty option and all children of the controls parent category value as possible options in the ComboBox.
        /// </summary>
        private void SpawnChildren()
        {
            cbbCategory.Items.Clear();
            cbbCategory.Items.Add("-");

            if (parent is not null)
            {
                var children = _categoryManager.GetChildren(parent);
                foreach (var child in children)
                {
                    cbbCategory.Items.Add(child);
                }
            }
            else
            {
                try
                {
                    var topLevel = _categoryManager.GetTopParents();
                    foreach (var topLevelItem in topLevel)
                    {
                        cbbCategory.Items.Add(topLevelItem);
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    MessageBox.Show("Error loading data.");
                    ParentForm.Close();
                }
            }
        }
    }
}
