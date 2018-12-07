using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wagner_DAmaral_Assignment01.Models;
using Wagner_DAmaral_Assignment01.Models.ViewModels;

namespace Wagner_DAmaral_Assignment01.Controllers
{

    [Authorize]
    public class ReviewController : Controller
    {
        private IRecipeRepository _recipeRepository;
        private IReviewRepository _reviewRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public ReviewController(IRecipeRepository recipeRepository, IReviewRepository reviewRepository,
            UserManager<IdentityUser> userManager)
        {
            _recipeRepository = recipeRepository;
            _reviewRepository = reviewRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ViewResult Reviews(Recipe recipe) =>
            View(_reviewRepository.Reviews.FirstOrDefault(r => r.Recipe == recipe));

        public async Task<IActionResult> Admin()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            return View("UserPage", _recipeRepository.Recipes.Where(r => r.UserId == currentUser.Id).ToList());
        }

        [HttpGet]
        public ViewResult AddReview(int recipeId)
        {
            //var currentUser = await _userManager.GetUserAsync(User);

            ReviewViewModel reviewViewModel = new ReviewViewModel()
            {
                RecipeID = recipeId
            };

            return View("Edit", reviewViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewViewModel reviewViewModel)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
                {
                if(reviewViewModel.ReviewID > 0)
                {
                    Review dbEntry = _reviewRepository.Reviews.FirstOrDefault(r => r.ReviewID == reviewViewModel.ReviewID &&
                                        r.UserId == currentUser.Id);
                    Recipe recipe = _recipeRepository.Recipes.FirstOrDefault(r => r.RecipeID == reviewViewModel.RecipeID);
                    if (dbEntry != null && recipe != null)
                    {
                        dbEntry.Recipe = recipe;
                        dbEntry.Stars = reviewViewModel.Review.Stars;
                        dbEntry.Description = reviewViewModel.Review.Description;

                        _reviewRepository.SaveReview(dbEntry);
                        TempData["message"] = $"Your review has been updated.";
                        return RedirectToAction("Admin");
                    }
                    TempData["errorMessage"] = $"You're not allowed to edit this review.";
                    return RedirectToAction("Admin");
                }
                else
                {

                
                    Recipe recipe = _recipeRepository.Recipes.FirstOrDefault(r => r.RecipeID == reviewViewModel.RecipeID);

                    reviewViewModel.Review.UserId = currentUser.Id;
                    recipe.AddReview(reviewViewModel.Review);
                    _reviewRepository.SaveReview(reviewViewModel.Review);
                    TempData["message"] = $"Your review has been saved";
                    return RedirectToAction("Admin");
                }
            }
            // there is something wrong with the data values
            return View("Edit", reviewViewModel);
        
        }

        [HttpGet]
        public async Task<IActionResult> EditReview(int reviewId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var reviewEdit = _reviewRepository.Reviews
                .FirstOrDefault(r => r.ReviewID == reviewId && r.UserId == currentUser.Id);
            if(reviewEdit != null)
            {
                ReviewViewModel reviewViewModel = new ReviewViewModel()
                {
                    RecipeID = reviewEdit.Recipe.RecipeID,
                    Review = reviewEdit
                };
                return View("Edit", reviewViewModel);
            }

            TempData["errorMessage"] = $"You're not allowed to edit this review.";
            return RedirectToAction("Admin");
        }

    }
}