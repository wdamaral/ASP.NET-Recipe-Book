using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wagner_DAmaral_Assignment01.Models.ViewModels;

namespace Wagner_DAmaral_Assignment01.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please add a picture URL")]
        public string PictureUrl { get; set; }

        [Required(ErrorMessage = "Please type a recipe name")]
        public string RecipeName { get; set; }

        [Required(ErrorMessage = "Please add a description")]
        [MinLength(50,
            ErrorMessage = "Description must have more than 50")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please add ingredients")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Please inform the cooking time")]
        [Range(1, 9999, ErrorMessage = "Preparing time must be above 0")]
        public int TimeToPrepare { get; set; }

        [Required(ErrorMessage = "Please inform the preparation steps")]
        public string PrepareMode { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? LastEdit { get; set; }
        public double Rating { get; private set; }


        public virtual void AddReview(Review review)
        {
            //need to find the user
            review.Recipe = this;
            Reviews.Add(review);

            double totalRating = 0;
            foreach (Review r in Reviews)
            {
                totalRating += r.Stars;
            }
            Rating = (totalRating / Reviews.Count);
        }

    }
}
