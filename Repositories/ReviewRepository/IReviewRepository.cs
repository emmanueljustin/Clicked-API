using ClickedApi.Data.Dto.Review.Request;
using ClickedApi.Data.Dto.Review.Response;
using ClickedApi.Models;

namespace ClickedApi.Repositories.ReviewRepository
{
    public interface IReviewRepository
    {
        public ICollection<Review> GetReviews();
        public Task<ReviewResponseDto> CreateReview(ReviewRequestDto request);
        public Task<bool> DeleteReview(int Id);
    }
}
