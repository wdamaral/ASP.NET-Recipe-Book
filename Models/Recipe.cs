using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wagner_DAmaral_Assignment01.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        [Required(ErrorMessage = "Please add a picture URL")]
        public string PictureUrl { get; set; }
        [Required(ErrorMessage = "Please type a recipe name")]
        public string RecipeName { get; set; }
        [Required(ErrorMessage = "Please add a description")]
        [StringLength(140, MinimumLength = 10,
            ErrorMessage = "Description must have 10 to 140 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please add ingredients")]
        public string Ingredients { get; set; }
        [Required(ErrorMessage = "Please inform the cooking time")]
        [Range(1, 9999, ErrorMessage = "Preparing time must be above 0")]
        public int TimeToPrepare { get; set; }
        [Required(ErrorMessage = "Please inform the preparation steps")]
        public string PrepareMode { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } 

        public int Rating { get; private set; }
        
        public virtual void AddReview(Review review)
        {
            review.Recipe = this;
            Reviews.Add(review);

            double avgRating = 0;
            foreach (Review r in Reviews)
            {
                avgRating += r.Stars;
            }
            Rating = (int)(avgRating / Reviews.Count);
        }

    }
}
