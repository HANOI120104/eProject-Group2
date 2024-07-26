namespace KarnelTravelGuideWeb.ViewModels
{
    public class TransportationVM
    {
        public int TransportId { get; set; }

        public string? Img { get; set; }

        public string Type { get; set; } = null!;

        public string? Description { get; set; }

        public bool? Availability { get; set; }

        public DateTime? CreatedAt { get; set; }

        public String City { get; set; }
    }
}
