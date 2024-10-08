using ClickedApi.Data.Dto.Pricing.Request;
using ClickedApi.Models;

namespace ClickedApi.Repositories.PricingRepository
{
    public interface IPricingRepository
    {
        public ICollection<Pricing> GetAllPricing();
        public Task<bool> SetPricing(PricingRequestDto request);
        public Task<bool> RemovePricing(int Id);
    }
} 
