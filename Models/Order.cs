using System;
using System.Collections.Generic;

namespace BakeryShop.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? StaffId { get; set; }

    public int? ShipperId { get; set; }

    public int? VoucherId { get; set; }

    public DateTime? DateTime { get; set; }

    public string? AdrDelivery { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Note { get; set; }

    public double? TotalPrice { get; set; }

    public string? Payment { get; set; }

    public string? Status { get; set; }

    public string? DenyReason { get; set; }

    public bool? HasFb { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Employee? Shipper { get; set; }

    public virtual Employee? Staff { get; set; }

    public virtual Voucher? Voucher { get; set; }
}
