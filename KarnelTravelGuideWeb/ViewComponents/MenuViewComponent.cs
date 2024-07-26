using KarnelTravelGuideWeb.Models;
using KarnelTravelGuideWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace qllaptop.ViewComponents
{
    
    public class MenuViewViewComponent : ViewComponent
    {
        private readonly KarnelTravelGuideContext _context;

        public MenuViewViewComponent(KarnelTravelGuideContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var city = _context.Cities.AsQueryable();
            var result = city.Select(c => new CityVM
            {
                Name = c.Name,
                CityId = c.CityId
            }).ToList();
            return View();
        }
    }
}
