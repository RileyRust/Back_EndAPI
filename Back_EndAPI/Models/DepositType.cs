using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class DepositType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DepositAccount> DepositAccounts { get; set; } = new List<DepositAccount>();
}
