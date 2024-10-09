using ClickedApi.Data;
using ClickedApi.Data.Dto.Review.Request;
using ClickedApi.Data.Dto.Review.Response;
using ClickedApi.Models;

namespace ClickedApi.Repositories.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public async Task<ReviewResponseDto> CreateReview(ReviewRequestDto request)
        {
            var newReview = new Review
            {
                Image = request.Image,
                Name = request.Name,
                Description = request.Description,
                Comment = request.Comment,
                Rating = request.Rating
            };

            await _context.Reviews.AddAsync(newReview);
            await _context.SaveChangesAsync();

            var response = new ReviewResponseDto
            {
                Image = newReview.Image,
                Name = newReview.Name,
                Description = newReview.Description,
                Comment = newReview.Comment,
                Rating = newReview.Rating
            };

            return response;

        }

        public async Task<bool> DeleteReview(int Id)
        {
            var review = await _context.Reviews.FindAsync(Id);

            if (review == null) return false;

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
