using System;
using System.Collections.Generic;

namespace BakeryShop.Models;

public partial class BlogPost
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime PublishedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string Author { get; set; } = null!;

    public string? Image { get; set; }
}
