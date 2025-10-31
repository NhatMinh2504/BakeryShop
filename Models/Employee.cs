using System;
using System.Collections.Generic;

namespace BakeryShop.Models;

public partial class Employee
{
    public int UserId { get; set; }

    public double Salary { get; set; }

    public DateOnly HiredDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Order> OrderShippers { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderStaffs { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;
}
