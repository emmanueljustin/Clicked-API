using ClickedApi.Data.Dto.Pricing.Request;
using ClickedApi.Data.Dto.Pricing.Response;
using ClickedApi.Data.Dto.RDto;
using ClickedApi.Data.Dto.Service.Response;
using ClickedApi.Models;
using ClickedApi.Service.PricingService;
using Microsoft.AspNetCore.Mvc;

namespace ClickedApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class PricingController : Controller
    {
        private readonly IPricingService _pricingService;

        public PricingController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        [HttpGet("get")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<List<PricingResponseDto>>))]
        public IActionResult GetAllPricing()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _pricingService.GetAllPricing();

            var response = result.Select(pricing => new PricingResponseDto
            {
                Id = pricing.Id,
                Title = pricing.Title,
                Description = pricing.Description,
                Services = pricing.Services.Select(service => new ServiceResponseDto
                {
                    Id = service.Id,
                    ServiceName = service.ServiceName,
                    IsIncluded = service.IsIncluded,
                }).ToList(),
                Price = pricing.Price,
            });

            var finalRes = new GenDtoResponseWBody<IEnumerable<PricingResponseDto>>
            {
                Status = "ok",
                Message = "Here is your requested pricing list.",
                Data = response
            };

            return Ok(finalRes);
        }

        [HttpPost("add")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pricing>))]
        public async Task<IActionResult> GetSample([FromBody] PricingRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _pricingService.SetPricing(request);

            GenDtoResponse response;

            if (result)
            {
                response = new GenDtoResponse
                {
                    Status = "ok",
                    Message = "Pricing are succesfully added."
                };
            }
            else
            {
                response = new GenDtoResponse
                {
                    Status = "err",
                    Message = "Oops! We cannot add the data you requested."
                };
            }

            return Ok(response);
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> RemovePricing([FromRoute] int Id)
        {
            var result = await _pricingService.RemovePricing(Id);

            GenDtoResponse response;

            if (!result)
            {
                response = new GenDtoResponse
                {
                    Status = "err",
                    Message = "Oops! An Error Occurred Please Try Again Later."
                };
            } else
            {
                response = new GenDtoResponse
                {
                    Status = "ok",
                    Message = "The pricing you selected has been succesfully deleted."
                };
            }

            return Ok(response);
        }
    }
}
