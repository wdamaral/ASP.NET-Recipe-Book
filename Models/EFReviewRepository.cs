using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Wagner_DAmaral_Assignment01.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context;
        public EFReviewRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Review> Reviews => context.Reviews
            .Include(rp => rp.Recipe);


        public void SaveReview(Review review)
        {
            context.Attach(review.Recipe);
            if (review.ReviewID == 0)
            {
                context.Reviews.Add(review);
            }
            context.SaveChanges();
        }
    }
}
