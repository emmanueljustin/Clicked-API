using AutoMapper;
using ClickedApi.Data.Dto.Pricing.Request;
using ClickedApi.Data.Dto.Pricing.Response;
using ClickedApi.Models;
using ClickedApi.Repositories.PricingRepository;

namespace ClickedApi.Service.PricingService
{
    public class PricingService : IPricingService
    {
        private readonly IPricingRepository _pricingRepository;

        public PricingService(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public IEnumerable<Pricing> GetAllPricing()
        {

            var pricings = _pricingRepository.GetAllPricing();

            return pricings;
        }

        public async Task<bool> SetPricing(PricingRequestDto request)
        {
            return await _pricingRepository.SetPricing(request);
        }

        public async Task<bool> RemovePricing(int Id)
        {
            return await _pricingRepository.RemovePricing(Id);
        }
    }
}
