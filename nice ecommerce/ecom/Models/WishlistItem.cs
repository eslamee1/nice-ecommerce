using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public partial class WishlistItem
{
    [Key]
    public int WishlistItemId { get; set; }

    public int? WishlistId { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Wishlist? Wishlist { get; set; }
}
