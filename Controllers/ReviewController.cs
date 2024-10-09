using ClickedApi.Data.Dto.RDto;
using ClickedApi.Data.Dto.Review.Request;
using ClickedApi.Data.Dto.Review.Response;
using ClickedApi.Models;
using ClickedApi.Service.ReviewService;
using Microsoft.AspNetCore.Mvc;

namespace ClickedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("get")]
        [ProducesResponseType(200, Type = typeof(GenDtoResponseWBody<List<Review>>))]
        public IActionResult GetReviews()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _reviewService.GetReviews();

            var response = new GenDtoResponseWBody<List<Review>>
            {
                Status = "ok",
                Message = "Successfully fetched reviews",
                Data = result.ToList(),
            };

            return Ok(response);
        }

        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(GenDtoResponseWBody<ReviewResponseDto>))]
        public async Task<IActionResult> CreateReview([FromBody] ReviewRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _reviewService.CreateReview(request);

            var response = new GenDtoResponseWBody<ReviewResponseDto>
            {
                Status = "ok",
                Message = "Successfully added a review",
                Data = result,
            };

            return Ok(response);
        }

        [HttpDelete("delete/{Id}")]
        [ProducesResponseType(200, Type = typeof(GenDtoResponse))]
        public async Task<IActionResult> DeleteReview([FromRoute] int Id)
        {
            var result = await _reviewService.DeleteReview(Id);

            GenDtoResponse response;

            if (!result)
            {
                response = new GenDtoResponse
                {
                    Status = "err",
                    Message = "Oops! An Error Occurred Please Try Again Later"
                };
            }
            else
            {
                response = new GenDtoResponse
                {
                    Status = "ok",
                    Message = "The review you selected has been succesfully deleted"
                };
            }

            return Ok(response);
        }
    }
}
