using EasyTools.MySqlDatabaseTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisEntities.Categories
{
    public class Category : IEquatable<Category>, IDataProvider
    {
        private int? id;
        private string name;
        private Category? parentCategory;

        public int ID => id.HasValue ? id.Value : throw new NullReferenceException();

        public string Name => name;

        public Category? Parent => parentCategory;
        public Category(string name)
        {
            id = null;
            this.name = name;
            parentCategory = null;
        }

        public Category(string name, Category parent)
        {
            id = null;
            this.name = name;
            parentCategory = parent;
        }

        public Category(int id, string name, Category? parent)
        {
            this.id = id;
            this.name = name;
            parentCategory = parent;
        }

        public Category GetRoot()
        {
            if(parentCategory is null)
            {
                return this;
            }
            else return parentCategory.GetRoot();
        }
        public override string ToString()
        {
            return name;
        }

        public Category? GetFromTree(int id)
        {
            if(parentCategory is null)
            {
                return null;
            }

            if (this.id == id)
            {
                return this;
            }
            else
            {
                return parentCategory.GetFromTree(id);
            }
        }

        /// <summary>
        /// Writes the names of all categories in this tree top-down
        /// as a string, seperated by arrows (\u2192).
        /// </summary>
        /// <returns></returns>
        public string GetTreeString()
        {
            if (parentCategory is null) //Recursion endpoint
            {
                return name;
            }
            return parentCategory.GetTreeString() + '\u2192' + name;
        }

#pragma warning disable CS8601
        /// <summary>
        /// Attempts to write this Categorys parent to the target.
        /// If there is no parent, the targets current value is unchanged.
        /// </summary>
        /// <param name="target">A reference to the variable to write to.</param>
        /// <returns>True if a parent exists, otherwise false.</returns>
        public bool TryGetParent(ref Category target)
        {
            bool hasParent = parentCategory is not null;

            if (hasParent)
                target = parentCategory;

            return hasParent;
        }
#pragma warning restore CS8601 

        public bool Equals(Category? other)
        {
            return id == other?.id;
        }

        public IParameterValueCollection GetParameterArgs()
        {
            var args = new ParameterValueCollection
            {
                { "id", id },
                { "name", name },
                { "parentId", parentCategory is not null ? parentCategory.ID : null }
            };
            return args;
        }
    }
}
