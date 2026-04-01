using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Taxid { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<AccountOwner> AccountOwners { get; set; } = new List<AccountOwner>();
}
