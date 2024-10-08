using ClickedApi.Data;
using ClickedApi.Data.Dto.Pricing.Request;
using ClickedApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ClickedApi.Repositories.PricingRepository
{
    public class PricingRepository : IPricingRepository
    {
        private readonly DataContext _context;

        public PricingRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Pricing> GetAllPricing()
        {
            return _context.Pricings.Include(p => p.Services).ToList();
        }

        public async Task<bool> SetPricing(PricingRequestDto request)
        {
            var newPricing = new Pricing
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                Services = new List<Services>()
            };

            foreach (var serviceDto in request.Services)
            {
                var service = new Services
                {
                    ServiceName = serviceDto.ServiceName,
                    IsIncluded = serviceDto.IsIncluded,
                };
                newPricing.Services.Add(service);
            }

            await _context.Pricings.AddAsync(newPricing);
            await _context.SaveChangesAsync();

            foreach (var service in newPricing.Services)
            {
                service.PricingId = newPricing.Id;
            }

            //await _context.Services.AddRangeAsync(newPricing.Services);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemovePricing(int Id)
        {
            var pricing = await _context.Pricings.FindAsync(Id);

            if (pricing == null) return false;

            _context.Pricings.Remove(pricing);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
