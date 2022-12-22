using SynthesisEntities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertHeijn_Desktop.Controls
{
    internal static class Extensions
    {
        /// <summary>
        /// Removes all CategoryPickers starting at a certain index.
        /// </summary>
        public static void RemoveAfter(this IList<CategoryPicker> self,int index)
        {
            for (int i = self.Count - 1; i > index; i--)
            {
                self.RemoveAt(i);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the object referenced by picker parameter is not referenced in the IList.</exception>
        public static void RemoveAfter(this IList<CategoryPicker> self, CategoryPicker picker)
        {
            if (!self.Contains(picker))
                throw new ArgumentException("Item not in collection.");
            for (int i = self.Count - 1; i > self.IndexOf(picker); i--)
            {
                self.RemoveAt(i);
            }
        }

        /// <summary>
        /// Removes all CategoryPickers starting at a certain index.
        /// </summary>
        public static void RemoveAfter(this Control.ControlCollection self, int index)
        {
            for (int i = self.Count - 1; i > index; i--)
            {
                self.RemoveAt(i);
            }
        }


        public static object Single(this Control.ControlCollection self)
        {
            if (self.Count == 1)
                return self[0];
            else
                throw new ArgumentException("More than 1 element.");
        }
    }
}
