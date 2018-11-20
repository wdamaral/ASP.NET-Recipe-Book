using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wagner_DAmaral_Assignment01.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get; }
        void SaveRecipe(Recipe recipe);
        Recipe DeleteRecipe(int recipeID);
    }
}
