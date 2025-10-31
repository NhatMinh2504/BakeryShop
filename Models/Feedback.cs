using System;
using System.Collections.Generic;

namespace BakeryShop.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? BakeryId { get; set; }

    public string? ContentFb { get; set; }

    public DateTime? Time { get; set; }

    public virtual BakeryOption? Bakery { get; set; }

    public virtual Customer? Customer { get; set; }
}
