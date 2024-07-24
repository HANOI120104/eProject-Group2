using System;
using System.Collections.Generic;

namespace KarnelTravelGuideWeb.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string? ContactMessage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Email { get; set; }
}
