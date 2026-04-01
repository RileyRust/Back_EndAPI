using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class AccountTxn
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public DateOnly TxnDate { get; set; }

    public string TxnType { get; set; } = null!;

    public decimal Amount { get; set; }

    public string Channel { get; set; } = null!;

    public int? EmployeeId { get; set; }

    public string? AtmTxnId { get; set; }

    public string? Memo { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Employee? Employee { get; set; }
}
