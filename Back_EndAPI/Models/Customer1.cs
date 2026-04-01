using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Customer1
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Tenancy> Tenancies { get; set; } = new List<Tenancy>();
}
