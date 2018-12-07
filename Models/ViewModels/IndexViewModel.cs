using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wagner_DAmaral_Assignment01.Models.ViewModels
{
    public class IndexViewModel
    {
        public Recipe TopRecipe { get; set; }
        public IEnumerable<Recipe> BestRated { get; set; }
        public IEnumerable<Recipe> MostRecent { get; set; }
    }
}
