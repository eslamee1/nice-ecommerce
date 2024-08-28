using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public partial class Wishlist
{
    [Key]
    public int WishlistId { get; set; }

    public int? UserId { get; set; }

    public virtual AppUser? AppUser { get; set; }

    public virtual ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
}
