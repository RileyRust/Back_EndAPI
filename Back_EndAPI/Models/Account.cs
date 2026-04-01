using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Account
{
    public int Id { get; set; }

    public DateOnly OpenedOn { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<AccountOwner> AccountOwners { get; set; } = new List<AccountOwner>();

    public virtual ICollection<AccountTxn> AccountTxns { get; set; } = new List<AccountTxn>();

    public virtual DepositAccount? DepositAccount { get; set; }

    public virtual LoanAccount? LoanAccount { get; set; }
}
