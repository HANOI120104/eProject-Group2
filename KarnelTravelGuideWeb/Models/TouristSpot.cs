using System;
using System.Collections.Generic;

namespace KarnelTravelGuideWeb.Models;

public partial class TouristSpot
{
    public int SpotId { get; set; }

    public string? Img { get; set; }

    public int? CityId { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Name { get; set; }

    public virtual City? City { get; set; }
}
