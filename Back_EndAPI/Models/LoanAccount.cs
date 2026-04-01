using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class LoanAccount
{
    public int AccountId { get; set; }

    public int LoanTypeId { get; set; }

    public decimal InterestRate { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual LoanType LoanType { get; set; } = null!;
}
