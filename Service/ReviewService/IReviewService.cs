using ClickedApi.Data.Dto.Review.Request;
using ClickedApi.Data.Dto.Review.Response;
using ClickedApi.Models;

namespace ClickedApi.Service.ReviewService
{
    public interface IReviewService
    {
        public IEnumerable<Review> GetReviews();
        public Task<ReviewResponseDto> CreateReview(ReviewRequestDto request);
        public Task<bool> DeleteReview(int Id);
    }
}
