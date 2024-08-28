using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public partial class ShoppingCart
{
    [Key]
    public int CartId { get; set; }

    public string? UserId { get; set; }

    public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

    public virtual AppUser? AppUser { get; set; }
}
