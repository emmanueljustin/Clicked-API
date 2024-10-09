namespace ClickedApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Image {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
