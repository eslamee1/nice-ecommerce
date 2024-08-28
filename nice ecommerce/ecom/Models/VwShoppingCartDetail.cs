using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public partial class VwShoppingCartDetail
{
    [Key]
    public int CartId { get; set; }

    public string Username { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal? Price { get; set; }
}
