using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public partial class ShippingDetail
{
    [Key]
    public int ShippingId { get; set; }

    public int? OrderId { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string ShippingMethod { get; set; } = null!;

    public string? TrackingNumber { get; set; }

    public DateOnly? ShippedDate { get; set; }

    public virtual Order? Order { get; set; }
}
