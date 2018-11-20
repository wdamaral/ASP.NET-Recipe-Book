using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wagner_DAmaral_Assignment01.Models;

namespace Wagner_DAmaral_Assignment01.Controllers
{
    public class RecipeController : Controller
    {
        private IRecipeRepository repository;

        public RecipeController(IRecipeRepository repo)
        {
            repository = repo;
        }
        
        public ViewResult DataPage() => View(repository.Recipes);

        public ViewResult DisplayPage(int recipeID) => 
            View(repository.Recipes
                .FirstOrDefault(r => r.RecipeID == recipeID));
        
        [HttpGet]
        public ViewResult Edit(int recipeId) =>
            View("InsertPage", repository.Recipes
            .FirstOrDefault(r => r.RecipeID == recipeId));

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.RecipeName} has been saved";
                return RedirectToAction("DataPage");
            }
            else
            {
                // there is something wrong with the data values
                return View("InsertPage", recipe);
            }
        }
        public ViewResult New() => View("InsertPage", new Recipe());

        [HttpGet]
        public IActionResult Delete(int recipeId)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(recipeId);
            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.RecipeName} was deleted";
            }
            return RedirectToAction("DataPage");
        }
    }
}