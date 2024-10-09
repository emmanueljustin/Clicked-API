using ClickedApi.Repositories.PricingRepository;
using ClickedApi.Repositories.ReviewRepository;
using ClickedApi.Service.PricingService;
using ClickedApi.Service.ReviewService;

namespace ClickedApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IPricingRepository, PricingRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();

            // Services
            services.AddScoped<IPricingService, PricingService>();
            services.AddScoped<IReviewService, ReviewService>();
        }
    }
}
