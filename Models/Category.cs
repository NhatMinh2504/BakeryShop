using System;
using System.Collections.Generic;

namespace BakeryShop.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Bakery> Bakeries { get; set; } = new List<Bakery>();
}
