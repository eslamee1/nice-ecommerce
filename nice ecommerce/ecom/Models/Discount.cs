using System;
using System.Collections.Generic;

namespace ecom.Models;

public partial class Discount
{
    public int DiscountId { get; set; }

    public string DiscountCode { get; set; } = null!;

    public decimal DiscountAmount { get; set; }

    public DateOnly ValidFrom { get; set; }

    public DateOnly ValidTo { get; set; }

    public string? Description { get; set; }
}
