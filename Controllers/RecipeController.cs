using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wagner_DAmaral_Assignment01.Models;

namespace Wagner_DAmaral_Assignment01.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        private IRecipeRepository repository;
        private UserManager<IdentityUser> _userManager;

        public RecipeController(IRecipeRepository repo,
            UserManager<IdentityUser> userManager)
        {
            repository = repo;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public ViewResult DataPage() => View(repository.Recipes);

        [AllowAnonymous]
        public ViewResult DisplayPage(int recipeID) => 
            View(repository.Recipes
                .FirstOrDefault(r => r.RecipeID == recipeID));
        
        [HttpGet]
        public async Task<IActionResult> Edit(int recipeId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            Recipe recipe = repository.Recipes.FirstOrDefault(r => r.RecipeID == recipeId && r.UserId == currentUser.Id);

            if(recipe != null)
            {
                return View("InsertPage", recipe);
            }
            TempData["errorMessage"] = $"You're not allowed to edit this recipe.";
            return RedirectToAction("Admin", "Review");


        }

        [HttpPost]
        public async Task<IActionResult> Edit(Recipe recipe)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                if (recipe.RecipeID > 0)
                {
                    Recipe editRecipe = repository.Recipes.FirstOrDefault(r => r.RecipeID == recipe.RecipeID && r.UserId == currentUser.Id);

                    if(editRecipe != null)
                    { 
                        editRecipe.LastEdit = DateTime.Now;
                        editRecipe.Description = recipe.Description;
                        editRecipe.Ingredients = recipe.Ingredients;
                        editRecipe.PictureUrl = recipe.PictureUrl;
                        editRecipe.RecipeName = recipe.RecipeName;
                        editRecipe.TimeToPrepare = recipe.TimeToPrepare;
                        repository.SaveRecipe(editRecipe);
                        TempData["message"] = $"{recipe.RecipeName} has been updated.";
                        return View("DataPage", repository.Recipes);
                    }
                    else
                    {
                        TempData["errorMessage"] = $"You're not allowed to edit this recipe.";
                        return View("DataPage", repository.Recipes);
                    }
                }
                else
                {
                    recipe.DateAdded = DateTime.Now;
                    recipe.UserId = currentUser.Id;
                    repository.SaveRecipe(recipe);
                    TempData["message"] = $"{recipe.RecipeName} has been saved";
                    return View("DataPage", repository.Recipes);
                }
            }
            else
            {
                // there is something wrong with the data values
                return View("InsertPage", recipe);
            }
            return View("DataPage", repository.Recipes);
        }
        public ViewResult New() => View("InsertPage", new Recipe());

        [HttpPost]
        public async Task<IActionResult> Delete(int recipeId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            Recipe aRecipe = repository.Recipes.FirstOrDefault(r => r.RecipeID == recipeId && r.UserId == currentUser.Id);

            if(aRecipe != null)
            {
                Recipe deletedRecipe = repository.DeleteRecipe(recipeId);
                if (deletedRecipe != null)
                {
                    TempData["message"] = $"{deletedRecipe.RecipeName} was deleted";
                }
                return RedirectToAction("DataPage");
            }
                TempData["errorMessage"] = $"You're not allowed to remove this recipe.";
                return RedirectToAction("UserPage");
            
        }
    }
}