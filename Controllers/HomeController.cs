using Microsoft.AspNetCore.Mvc;
using Wagner_DAmaral_Assignment01.Models;
using System.Linq;
using Wagner_DAmaral_Assignment01.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wagner_DAmaral_Assignment01.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeRepository repository;
        public HomeController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            IndexViewModel index = new IndexViewModel
            {
                MostRecent = repository.Recipes
                 .OrderByDescending(r => r.DateAdded)
                 .Take(4).ToList(),

                BestRated = repository.Recipes
                .OrderByDescending(r => r.Rating)
                .Take(3).ToList()
            };
            index.TopRecipe = index.BestRated.First();

            return View(index);
        }
        
    }
}
