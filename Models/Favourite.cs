using System;
using System.Collections.Generic;

namespace BakeryShop.Models;

public partial class Favourite
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? BakeryId { get; set; }

    public virtual BakeryOption? Bakery { get; set; }

    public virtual Customer? Customer { get; set; }
}
