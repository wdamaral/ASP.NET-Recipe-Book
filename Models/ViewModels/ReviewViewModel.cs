using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wagner_DAmaral_Assignment01.Models;

namespace Wagner_DAmaral_Assignment01.Models.ViewModels
{
    public class ReviewViewModel
    {
        public int RecipeID { get; set; }
        public int ReviewID { get; set; }
        public Review Review { get; set; }
    }
}

