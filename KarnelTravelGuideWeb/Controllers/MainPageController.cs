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

        public IActionResult Index()
        {
            var hotel = _context.Hotels.Include(p => p.City).AsQueryable();
            var resort = _context.Resorts.AsQueryable();
            var resultResort = resort.Select(p => new ResortVM
            {
                Name = p.Name,
                Img = p.Img,
                Price = p.Price,
                Description = p.Description
            }).ToList();
            var result = hotel.Select(p => new HotelVM
            {
                Name = p.Name,
                Img = p.Img,
                Price = p.Price,
                Description = p.Description,
                Country = p.City.Country
            }).ToList();
            ViewBag.Hotels = result;
            ViewBag.Resorts = resultResort;
            return View();
        }

        [HttpPost]
        public IActionResult Search(string query)
        {
            decimal.TryParse(query, out var price);
            var hotels = _context.Hotels
                .Include(h => h.City)
                .Where(h => h.Name.Contains(query) || h.Description.Contains(query) || h.Price == price)
                .Select(h => new HotelVM
                {
                    Name = h.Name,
                    Img = h.Img,
                    Price = h.Price,
                    Description = h.Description
                }).ToList();

            var resorts = _context.Resorts
                .Where(r => r.Name.Contains(query))
                .Select(r => new ResortVM
                {
                    Name = r.Name,
                    Img = r.Img,
                    Price = r.Price,
                    Description = r.Description
                }).ToList();

            var searchResults = new SearchResultsVM
            {
                Hotels = hotels,
                Resorts = resorts
            };

            // Return the view with the search results model
            return View(searchResults);
        }
    }
}
