using System;
using System.Collections.Generic;

namespace BakeryShop.Models;

public partial class OrderItem
{
    public int Id { get; set; }

    public int? BakeryId { get; set; }

    public int? CustomerId { get; set; }

    public int? OrderId { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public virtual BakeryOption? Bakery { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Order? Order { get; set; }
}
