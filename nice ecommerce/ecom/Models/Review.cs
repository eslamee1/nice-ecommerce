using System;
using System.Collections.Generic;

namespace ecom.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public int? Rating { get; set; }

    public string? ReviewText { get; set; }

    public virtual Product? Product { get; set; }

    public virtual AppUser? AppUser { get; set; }
}
