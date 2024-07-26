namespace KarnelTravelGuideWeb.ViewModels
{
    public class ResortVM
    {
        public int ResortId { get; set; }

        public string? Img { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int QualityRating { get; set; }

        public bool? Availability { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public String City { get; set; }
    }
}
