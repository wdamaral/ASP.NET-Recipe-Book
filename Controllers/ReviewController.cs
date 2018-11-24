using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wagner_DAmaral_Assignment01.Models;
using Wagner_DAmaral_Assignment01.Models.ViewModels;

namespace Wagner_DAmaral_Assignment01.Controllers
{
    public class ReviewController : Controller
    {
        private IRecipeRepository _recipeRepository;
        private IReviewRepository _reviewRepository;

        public ReviewController(IRecipeRepository recipeRepository, IReviewRepository reviewRepository)
        {
            _recipeRepository = recipeRepository;
            _reviewRepository = reviewRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Reviews(Recipe recipe) =>
            View(_reviewRepository.Reviews.FirstOrDefault(r => r.Recipe == recipe));

        public IActionResult Admin()
        {
            return View("UserPage", _recipeRepository.Recipes);
        }

        [HttpGet]
        public ViewResult AddReview(int recipeId)
        {
            
            ReviewViewModel reviewViewModel = new ReviewViewModel()
            {
                RecipeID = recipeId
            };

            return View("Edit", reviewViewModel);
        }
        [HttpPost]
        public IActionResult AddReview(ReviewViewModel reviewViewModel)
        {
                
                if (ModelState.IsValid)
                {
                    Recipe recipe = _recipeRepository.Recipes.FirstOrDefault(r => r.RecipeID == reviewViewModel.RecipeID);

                    recipe.AddReview(reviewViewModel.Review);
                    _reviewRepository.SaveReview(reviewViewModel.Review);
                    TempData["message"] = $"Your review has been saved";
                    return RedirectToAction("Admin");
                }
                else
                {
                    // there is something wrong with the data values
                    return View("Edit", reviewViewModel);
                }
        }
    }
}