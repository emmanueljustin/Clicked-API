namespace ClickedApi.Models
{
    public class Services
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public bool IsIncluded { get; set; }
        public int PricingId { get; set; }
        public Pricing Pricing { get; set; }
    }
}
