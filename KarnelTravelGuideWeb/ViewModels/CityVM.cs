namespace KarnelTravelGuideWeb.ViewModels
{
    public class CityVM
    {
        public int CityId { get; set; }

        public string Name { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string? Img { get; set; }
    }
}
