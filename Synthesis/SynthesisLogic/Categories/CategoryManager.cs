using EasyTools.Validation;
using SynthesisDataLayer.Categories;
using SynthesisEntities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisLogic.Categories
{
    public class CategoryManager
    {
        private readonly ICategoryRepo dataSource;

        public CategoryManager(ICategoryRepo repo)
        {
            dataSource = repo;
        }

        public IReadOnlyCollection<Category> GetTopParents()
        {
            return dataSource.ReadTopLevel();
        }

        public IReadOnlyCollection<Category> GetChildren(Category parent)
        {
            return dataSource.NextGeneration(parent);
        }

        public Category? GetById(int? id)
        {
            if(id is null)
                return null;
            return dataSource.GetByPrimaryKey(id.Value);
        }

        public IValidationResponse CreateNew(Category category)
        {
            return dataSource.Insert(category);
        }

        public IValidationResponse Update(Category category)
        {
            return dataSource.Update(category);
        }
    }
}
