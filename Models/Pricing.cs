using ClickedApi.Service.PricingService;

namespace ClickedApi.Models
{
    public class Pricing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Services> Services { get; set; } = new List<Services>();
        public double Price { get; set; }
    }
}
