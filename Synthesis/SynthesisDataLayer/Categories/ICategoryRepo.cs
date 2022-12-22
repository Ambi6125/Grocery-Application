using EasyTools.Validation;
using SynthesisEntities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisDataLayer.Categories
{
    public interface ICategoryRepo
    {
        IReadOnlyCollection<Category> ReadTopLevel();
        IReadOnlyCollection<Category> NextGeneration(Category category);
        IValidationResponse Insert(Category category);
        IValidationResponse Update(Category category);
    }
}
