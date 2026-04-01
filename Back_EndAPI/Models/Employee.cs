using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Eeid { get; set; } = null!;

    public string Taxid { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public virtual ICollection<AccountTxn> AccountTxns { get; set; } = new List<AccountTxn>();
}
