using System;
using System.Collections.Generic;

namespace KarnelTravelGuideWeb.Models;

public partial class City
{
    public int CityId { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? Img { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ICollection<Resort> Resorts { get; set; } = new List<Resort>();

    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();

    public virtual ICollection<TouristSpot> TouristSpots { get; set; } = new List<TouristSpot>();

    public virtual ICollection<Transportation> Transportations { get; set; } = new List<Transportation>();
}
