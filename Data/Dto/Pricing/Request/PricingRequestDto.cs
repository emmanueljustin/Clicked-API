using ClickedApi.Data.Dto.Service.Request;
using ClickedApi.Models;

namespace ClickedApi.Data.Dto.Pricing.Request
{
    public class PricingRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ServiceRequestDto> Services { get; set; }
        public double Price { get; set; }
    }
}
