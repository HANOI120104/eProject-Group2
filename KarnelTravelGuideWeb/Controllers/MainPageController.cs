using KarnelTravelGuideWeb.Models;
using KarnelTravelGuideWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelGuideWeb.Controllers
{
    public class MainPageController : Controller
    {
        private readonly KarnelTravelGuideContext _context;

        public MainPageController(KarnelTravelGuideContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? loai)
        {
            var hotel = _context.Hotels.Include(p => p.City).AsQueryable();
            var resort = _context.Resorts.AsQueryable();
            var city = _context.Cities.AsQueryable();
            var touristSpot = _context.TouristSpots.AsQueryable();
            if (loai.HasValue)
            {
                touristSpot = touristSpot.Where(h => h.CityId == loai.Value);

            }
            var resultCity = city.Select(c => new CityVM
            {
                Name = c.Name,
                CityId = c.CityId
            }).ToList();
            var result = touristSpot.Select(t => new TouristSpotVM
            {
                Name = t.Name

            });
            ViewBag.Cities = resultCity;
            ViewBag.TouristSpots = result;
            return View();
        }

        public IActionResult Search(string query, string country, string type, int? cityId, decimal? maxPrice, List<int> quality, string sort)
        {
            var hotelsQuery = _context.Hotels.Include(h => h.City).AsQueryable();
            var resortsQuery = _context.Resorts.Include(r => r.City).AsQueryable();
            var touristsQuery = _context.TouristSpots.Include(t => t.City).AsQueryable();
            var restaurantsQuery = _context.Restaurants.Include(r => r.City).AsQueryable();

            // Apply search filters
            if (!string.IsNullOrEmpty(query))
            {
                hotelsQuery = hotelsQuery.Where(h => h.Name.Contains(query) || h.Description.Contains(query) || h.City.Name.Contains(query));
                resortsQuery = resortsQuery.Where(r => r.Name.Contains(query) || r.Description.Contains(query) || r.City.Name.Contains(query));
                touristsQuery = touristsQuery.Where(t => t.Name.Contains(query) || t.Description.Contains(query) || t.City.Name.Contains(query));
                restaurantsQuery = restaurantsQuery.Where(r => r.Name.Contains(query) || r.Description.Contains(query) || r.City.Name.Contains(query));
            }

            if (!string.IsNullOrEmpty(country))
            {
                hotelsQuery = hotelsQuery.Where(h => h.City.Country == country);
                resortsQuery = resortsQuery.Where(r => r.City.Country == country);
                touristsQuery = touristsQuery.Where(t => t.City.Country == country);
                restaurantsQuery = restaurantsQuery.Where(r => r.City.Country == country);
            }

            if (cityId.HasValue)
            {
                hotelsQuery = hotelsQuery.Where(h => h.CityId == cityId);
                resortsQuery = resortsQuery.Where(r => r.CityId == cityId);
                touristsQuery = touristsQuery.Where(t => t.CityId == cityId);
                restaurantsQuery = restaurantsQuery.Where(r => r.CityId == cityId);
            }

            if (maxPrice.HasValue)
            {
                hotelsQuery = hotelsQuery.Where(h => h.Price <= maxPrice);
                resortsQuery = resortsQuery.Where(r => r.Price <= maxPrice);
                restaurantsQuery = restaurantsQuery.Where(r => r.Price <= maxPrice);
            }

           // if (quality != null && quality.Any())
           // {
           //     hotelsQuery = hotelsQuery.Where(h => quality.Contains(h.Quality));
           //     resortsQuery = resortsQuery.Where(r => quality.Contains(r.Quality));
          //  }

            // Apply sorting
            switch (sort)
            {
                case "price_asc":
                    hotelsQuery = hotelsQuery.OrderBy(h => h.Price);
                    resortsQuery = resortsQuery.OrderBy(r => r.Price);
                    restaurantsQuery = restaurantsQuery.OrderBy(r => r.Price);
                    break;
                case "price_desc":
                    hotelsQuery = hotelsQuery.OrderByDescending(h => h.Price);
                    resortsQuery = resortsQuery.OrderByDescending(r => r.Price);
                    restaurantsQuery = restaurantsQuery.OrderByDescending(r => r.Price);
                    break;
                default:
                    // Default sorting, e.g., by name
                    hotelsQuery = hotelsQuery.OrderBy(h => h.Name);
                    resortsQuery = resortsQuery.OrderBy(r => r.Name);
                    touristsQuery = touristsQuery.OrderBy(t => t.Name);
                    restaurantsQuery = restaurantsQuery.OrderBy(r => r.Name);
                    break;
            }

            var hotels = hotelsQuery.Select(h => new HotelVM
            {
                HotelId = h.HotelId,
                Name = h.Name,
                Img = h.Img,
                Price = h.Price,
                Description = h.Description,
                City = h.City.Name
            }).ToList();

            var resorts = resortsQuery.Select(r => new ResortVM
            {
                ResortId = r.ResortId,
                Name = r.Name,
                Img = r.Img,
                Price = r.Price,
                Description = r.Description,
                City = r.City.Name
            }).ToList();

            var tourists = touristsQuery.Select(t => new TouristSpotVM
            {
                SpotId = t.SpotId,
                Name = t.Name,
                Img = t.Img,
                Description = t.Description,
                City = t.City.Name
            }).ToList();

            var restaurants = restaurantsQuery.Select(r => new RestaurantVM
            {
                RestaurantId = r.RestaurantId,
                Name = r.Name,
                Img = r.Img,
                Price = r.Price,
                Description = r.Description,
                City = r.City.Name
            }).ToList();

            var cities = _context.Cities.Select(c => new CityVM
            {
                Name = c.Name,
                CityId = c.CityId
            }).ToList();

            var searchResults = new SearchResultsVM
            {
                Hotels = hotels,
                Resorts = resorts,
                Tourists = tourists,
                Restaurants = restaurants,
                Cities = cities
            };

            return View(searchResults);
        }

        [HttpPost]
        public IActionResult Search(string? query)
        {
            var hotelsQuery = _context.Hotels.Include(h => h.City).AsQueryable();
            var resortsQuery = _context.Resorts.Include(h => h.City).AsQueryable();
            var citiesQuery = _context.Cities.AsQueryable();
            var touristQuery = _context.TouristSpots.AsQueryable();
            var restaurantQuery = _context.Restaurants.AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                decimal.TryParse(query, out var price);
                hotelsQuery = hotelsQuery.Where(h => h.Name.Contains(query) || h.Description.Contains(query) || h.Price == price);
                resortsQuery = resortsQuery.Where(r => r.Name.Contains(query));
                touristQuery = touristQuery.Where(t => t.Name.Contains(query));
                restaurantQuery = restaurantQuery.Where(r => r.Name.Contains(query));
            }

            var hotels = hotelsQuery.Select(h => new HotelVM
            {
                HotelId = h.HotelId,
                Name = h.Name,
                Img = h.Img,
                Price = h.Price,
                Description = h.Description,
                City = h.City.Name
            }).ToList();

            var resorts = resortsQuery.Select(r => new ResortVM
            {
                ResortId = r.ResortId,
                Name = r.Name,
                Img = r.Img,
                Price = r.Price,
                Description = r.Description,
                City = r.City.Name
            }).ToList();

            var tourists = touristQuery.Select(t => new TouristSpotVM
            {
                SpotId = t.SpotId,
                Img = t.Img,
                Name = t.Name,
                Description = t.Description,
                City = t.City.Name
            }).ToList();

            var restaurants = restaurantQuery.Select(re => new RestaurantVM
            {
                RestaurantId = re.RestaurantId,
                Img = re.Img,
                Name = re.Name,
                Price = re.Price,
                Description = re.Description,
                City = re.City.Name
            }).ToList();

            var cities = citiesQuery.Select(c => new CityVM
            {
                Name = c.Name,
                CityId = c.CityId
            }).ToList();

            var searchResults = new SearchResultsVM
            {
                Hotels = hotels,
                Resorts = resorts,
                Cities = cities,
                Tourists = tourists,
                Restaurants = restaurants
            };

            return View(searchResults);
        }

        public IActionResult Information(string infoType)
        {
            ViewBag.InfoType = infoType;

            switch (infoType?.ToLower())
            {
                case "hotel":
                    var hotels = _context.Hotels.Include(h => h.City)
                        .Select(h => new HotelVM
                        {
                            HotelId = h.HotelId,
                            Name = h.Name,
                            Img = h.Img,
                            Price = h.Price,
                            Description = h.Description,
                            City = h.City.Country
                        }).ToList();
                    return View(hotels);

                case "touristspot":
                    var touristSpots = _context.TouristSpots.Include(t => t.City)
                        .Select(t => new TouristSpotVM
                        {
                            SpotId = t.SpotId,
                            Name = t.Name,
                            Img = t.Img,
                            Description = t.Description,
                            City = t.City.Country
                        }).ToList();
                    return View(touristSpots);

                case "restaurant":
                    var restaurants = _context.Restaurants.Include(r => r.City)
                        .Select(r => new RestaurantVM
                        {
                            RestaurantId = r.RestaurantId,
                            Name = r.Name,
                            Img = r.Img,
                            Price = r.Price,
                            Description = r.Description,
                            City = r.City.Country
                        }).ToList();
                    return View(restaurants);

                case "resort":
                    var resorts = _context.Resorts.Include(r => r.City)
                        .Select(r => new ResortVM
                        {
                            ResortId = r.ResortId,
                            Name = r.Name,
                            Img = r.Img,
                            Price = r.Price,
                            Description = r.Description,
                            City = r.City.Country
                        }).ToList();
                    return View(resorts);

                case "transportation":
                    // Assuming you have a Transportation model and ViewModel
                    var transportation = _context.Transportations.Include(t => t.City)
                        .Select(t => new TransportationVM
                        {
                            TransportId = t.TransportId,
                            Type = t.Type,
                            Img = t.Img,                           
                            Description = t.Description,
                            City = t.City.Country
                        }).ToList();
                    return View(transportation);

                default:
                    return View(new List<dynamic>()); // Return an empty list if no valid type is specified
            }
        }

        public IActionResult Contact()
        {
            var recentFeedbacks = _context.Contacts
                .OrderByDescending(c => c.CreatedAt)
                .Take(3)
                .Select(c => new ContactVM
                {
                    Email = c.Email,
                    ContactMessage = c.ContactMessage
                })
                .ToList();

            return View(recentFeedbacks);
        }

        [HttpPost]
        public IActionResult AddContact(ContactVM model)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact
                {
                    Email = model.Email,
                    ContactMessage = model.ContactMessage,
                    CreatedAt = DateTime.Now
                };

                _context.Contacts.Add(contact);
                _context.SaveChanges();

                return RedirectToAction(nameof(Contact));
            }

            return View("Contact", model);
        }

        public IActionResult Details(int id, string type)
        {
            switch (type.ToLower())
            {
                case "hotel":
                    var hotel = _context.Hotels.Include(h => h.City).FirstOrDefault(h => h.HotelId == id);
                    if (hotel == null) return NotFound();
                    return View(new HotelVM
                    {
                        HotelId = hotel.HotelId,
                        Name = hotel.Name,
                        Img = hotel.Img,
                        Price = hotel.Price,
                        Description = hotel.Description,
                        City = hotel.City.Name
                    });

                case "resort":
                    var resort = _context.Resorts.Include(r => r.City).FirstOrDefault(r => r.ResortId == id);
                    if (resort == null) return NotFound();
                    return View(new ResortVM
                    {
                        ResortId = resort.ResortId,
                        Name = resort.Name,
                        Img = resort.Img,
                        Price = resort.Price,
                        Description = resort.Description,
                        City = resort.City.Name
                    });

                case "touristspot":
                    var spot = _context.TouristSpots.Include(t => t.City).FirstOrDefault(t => t.SpotId == id);
                    if (spot == null) return NotFound();
                    return View(new TouristSpotVM
                    {
                        SpotId = spot.SpotId,
                        Name = spot.Name,
                        Img = spot.Img,
                        Description = spot.Description,
                        City = spot.City.Name
                    });

                case "restaurant":
                    var restaurant = _context.Restaurants.Include(r => r.City).FirstOrDefault(r => r.RestaurantId == id);
                    if (restaurant == null) return NotFound();
                    return View(new RestaurantVM
                    {
                        RestaurantId = restaurant.RestaurantId,
                        Name = restaurant.Name,
                        Img = restaurant.Img,
                        Price = restaurant.Price,
                        Description = restaurant.Description,
                        City = restaurant.City.Name
                    });

                case "transportation":
                    var transport = _context.Transportations.Include(t => t.City).FirstOrDefault(t => t.TransportId == id);
                    if (transport == null) return NotFound();
                    return View(new TransportationVM
                    {
                        TransportId = transport.TransportId,
                        Type = transport.Type,
                        Img = transport.Img,
                        Description = transport.Description,
                        City = transport.City.Name
                    });

                default:
                    return NotFound();
            }
        }
    }
}