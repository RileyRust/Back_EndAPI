using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class LoanType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<LoanAccount> LoanAccounts { get; set; } = new List<LoanAccount>();
}
