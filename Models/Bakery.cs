using System;
using System.Collections.Generic;

namespace BakeryShop.Models;

public partial class Bakery
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Image { get; set; }

    public string? Description { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public int CategoryId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<BakeryOption> BakeryOptions { get; set; } = new List<BakeryOption>();

    public virtual Category Category { get; set; } = null!;
}
