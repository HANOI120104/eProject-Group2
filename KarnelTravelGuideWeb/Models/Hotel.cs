using System;
using System.Collections.Generic;

namespace KarnelTravelGuideWeb.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string? Img { get; set; }

    public string Name { get; set; } = null!;

    public int? CityId { get; set; }

    public decimal Price { get; set; }

    public int QualityRating { get; set; }

    public bool? Availability { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual City? City { get; set; }
}
