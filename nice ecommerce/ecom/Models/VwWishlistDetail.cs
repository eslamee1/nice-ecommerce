using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public partial class VwWishlistDetail
{
    [Key]
    public int WishlistId { get; set; }

    public string Username { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal? Price { get; set; }
}
