using ClickedApi.Data.Dto.Review.Request;
using ClickedApi.Data.Dto.Review.Response;
using ClickedApi.Models;
using ClickedApi.Repositories.ReviewRepository;

namespace ClickedApi.Service.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public IEnumerable<Review> GetReviews()
        {
            return _reviewRepository.GetReviews();
        }

        public async Task<ReviewResponseDto> CreateReview(ReviewRequestDto request)
        {
            return await _reviewRepository.CreateReview(request);
        }

        public async Task<bool> DeleteReview(int Id)
        {
            return await _reviewRepository.DeleteReview(Id);
        }
    }
}
