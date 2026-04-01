using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Payment1
{
    public int PaymentId { get; set; }

    public int BillId { get; set; }

    public DateOnly PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public virtual Bill Bill { get; set; } = null!;
}
