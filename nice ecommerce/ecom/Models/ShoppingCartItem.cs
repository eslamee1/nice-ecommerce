using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public partial class ShoppingCartItem
{
    [Key]
    public int CartItemId { get; set; }

    public int? CartId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual ShoppingCart? Cart { get; set; }

    public virtual Product? Product { get; set; }
}
