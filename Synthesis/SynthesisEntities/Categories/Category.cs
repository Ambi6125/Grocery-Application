using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisEntities.Categories
{
    public class Category
    {
        private int? id;
        private string name;
        private Category? parentCategory;

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
            if (parentCategory is null) //Recursion endpoint
            {
                return name;
            }
            return parentCategory.ToString() + '\u2192' + name;
        }
    }



    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
