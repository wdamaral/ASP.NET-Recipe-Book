using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wagner_DAmaral_Assignment01.Models
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        void SaveReview(Review review);
    }
}
