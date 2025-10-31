using System;
using System.Collections.Generic;

namespace BakeryShop.Models;

public partial class BakeryOption
{
    public int Id { get; set; }

    public int? Size { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public double? Rating { get; set; }

    public int? Discount { get; set; }

    public int BakeryId { get; set; }

    public virtual Bakery Bakery { get; set; } = null!;

    public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
