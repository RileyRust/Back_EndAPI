using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int TenancyId { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public virtual Tenancy Tenancy { get; set; } = null!;
}
