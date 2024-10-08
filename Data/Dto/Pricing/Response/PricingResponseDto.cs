using ClickedApi.Data.Dto.Service.Response;

namespace ClickedApi.Data.Dto.Pricing.Response
{
    public class PricingResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ServiceResponseDto> Services { get; set; }
        public double Price { get; set; }
    }
}
