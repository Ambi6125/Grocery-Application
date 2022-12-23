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
    public partial class CategoryFlowBox : UserControl
    {
        private List<CategoryPicker> allPickers;
        private readonly CategoryManager manager;


        public Category SelectedCategory
        {

            get
            {
                if (allPickers.Count < 2)
                {
                    return (Category)allPickers.Single().ComboBox.SelectedItem;
                }
                else
                {
                    int targetIndex = allPickers.Count - 2; //Second to last in zero-absed index
                    return (Category)allPickers.ElementAt(targetIndex).ComboBox.SelectedItem;
                }
            }
        }

        public CategoryFlowBox(CategoryManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            allPickers = new List<CategoryPicker>();
        }

        private void RedrawGeneration(object sender, EventArgs e)
        {
            if (sender is ComboBox cbb)
            {
                int drawnIndexOfCaller = flpBoxes.Controls.IndexOf(cbb.Parent);
                allPickers.RemoveAfter(drawnIndexOfCaller);
                flpBoxes.Controls.RemoveAfter(drawnIndexOfCaller);
            }
            else
                throw new InvalidOperationException("Can only redraw CategoryPickers. The current sender was not of this type.");
        }
        
        private void SpawnNew(object sender, EventArgs e)
        {
            var lastPicker = flpBoxes.Controls.Cast<CategoryPicker>().LastOrDefault().Selection;
            if(lastPicker is null)
            {
                return;
            }
            CategoryPicker cp = new CategoryPicker(manager, lastPicker, allPickers.Count);
            cp.ComboBox.SelectedIndexChanged += RedrawGeneration;
            cp.ComboBox.SelectedIndexChanged += SpawnNew; //If the child has its selection changed, call this method to redraw lower generations

            flpBoxes.Controls.Add(cp);
            allPickers.Add(cp);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            CategoryPicker cp = new CategoryPicker(manager, null, allPickers.Count);
            cp.ComboBox.SelectedIndexChanged += RedrawGeneration;
            cp.ComboBox.SelectedIndexChanged += SpawnNew;
            flpBoxes.Controls.Add(cp);
            allPickers.Add(cp);
        }
    }
}
