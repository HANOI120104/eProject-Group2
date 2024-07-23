using System;
using System.Collections.Generic;

namespace KarnelTravelGuideWeb.Models;

public partial class Transportation
{
    public int TransportId { get; set; }

    public string? Img { get; set; }

    public string Type { get; set; } = null!;

    public int? CityId { get; set; }

    public string? Description { get; set; }

    public bool? Availability { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual City? City { get; set; }
}
