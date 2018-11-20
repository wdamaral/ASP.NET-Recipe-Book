using Microsoft.AspNetCore.Mvc;
using Wagner_DAmaral_Assignment01.Models;
using System.Linq;

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
            return View();
        }
        
    }
}
