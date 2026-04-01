using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class AccountOwner
{
    public int AccountId { get; set; }

    public int CustomerId { get; set; }

    public bool IsPrimary { get; set; }

    public DateOnly AddedOn { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
