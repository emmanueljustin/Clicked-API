using ClickedApi.Repositories.PricingRepository;
using ClickedApi.Service.PricingService;

namespace ClickedApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IPricingRepository, PricingRepository>();

            // Services
            services.AddScoped<IPricingService, PricingService>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IGoalService, GoalService>();
        }
    }
}
