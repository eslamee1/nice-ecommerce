using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public partial class VwOrderDetail
{
    [Key]
    public int OrderId { get; set; }

    public string Username { get; set; } = null!;

    public DateOnly OrderDate { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal TotalAmount { get; set; }
}
