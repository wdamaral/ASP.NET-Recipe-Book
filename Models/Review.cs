﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wagner_DAmaral_Assignment01.Models
{
    public class Review
    {
        [BindNever]
        public int ReviewID { get; set; }
        [Required(ErrorMessage = "Number of stars is required")]
        [Range(0,5, ErrorMessage = "Number of stars must be between 0 to 5")]
        public double Stars { get; set; }

        [Required(ErrorMessage = "Please add your review")]
        public string Description { get; set; }
        public Recipe Recipe { get; set; }
    }
}
