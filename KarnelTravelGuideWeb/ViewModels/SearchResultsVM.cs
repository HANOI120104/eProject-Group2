namespace KarnelTravelGuideWeb.ViewModels
{
    public class SearchResultsVM
    {
        public List<HotelVM> Hotels { get; set; } 
        public List<ResortVM> Resorts { get; set; } 
        
        public List<TouristSpotVM> Tourists { get; set; }
        public List<CityVM> Cities { get; set; }

        public List<RestaurantVM> Restaurants { get; set;}
    }
}
