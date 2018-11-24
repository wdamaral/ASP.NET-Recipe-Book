using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wagner_DAmaral_Assignment01.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes => context.Recipes
            .Include(rw => rw.Reviews);

        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.RecipeID == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                Recipe dbEntry = context.Recipes
                .FirstOrDefault(r => r.RecipeID == recipe.RecipeID);
                if (dbEntry != null)
                {
                    dbEntry.RecipeName = recipe.RecipeName;
                    dbEntry.Description = recipe.Description;
                    dbEntry.PrepareMode = recipe.PrepareMode;
                    dbEntry.PictureUrl = recipe.PictureUrl;
                    dbEntry.PrepareMode = recipe.PrepareMode;
                    dbEntry.TimeToPrepare = recipe.TimeToPrepare;
                    dbEntry.Reviews = recipe.Reviews;
                }
            }
            context.SaveChanges();
        }

        public Recipe DeleteRecipe(int recipeID)
        {
            Recipe dbEntry = context.Recipes
                .Include(r => r.Reviews)
                .FirstOrDefault(r => r.RecipeID == recipeID);
            if (dbEntry != null)
            {
                context.Recipes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
