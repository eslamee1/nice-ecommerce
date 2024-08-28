using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public partial class PaymentDetail
{
    [Key]
    public int PaymentId { get; set; }

    public int? OrderId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public DateOnly PaymentDate { get; set; }

    public string? ReferenceNumber { get; set; }

    public virtual Order? Order { get; set; }
}
