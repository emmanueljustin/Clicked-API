using ClickedApi.Data.Dto.Pricing.Request;
using ClickedApi.Data.Dto.Pricing.Response;
using ClickedApi.Models;

namespace ClickedApi.Service.PricingService
{
    public interface IPricingService
    {
        public IEnumerable<Pricing> GetAllPricing();
        public Task<bool> SetPricing(PricingRequestDto request);
        public Task<bool> RemovePricing(int Id);
    }
}
