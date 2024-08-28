using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public partial class VwUserOrderHistory
{
    [Key]
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public int OrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public decimal TotalAmount { get; set; }
}
