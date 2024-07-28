using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KarnelTravelGuideWeb.Models;

public partial class Contact
{
    public string? ContactMessage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Email { get; set; }

    [Key]
    public int ContactId { get; set; }
}
