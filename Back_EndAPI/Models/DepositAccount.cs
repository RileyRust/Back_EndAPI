using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class DepositAccount
{
    public int AccountId { get; set; }

    public int DepositTypeId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual DepositType DepositType { get; set; } = null!;
}
