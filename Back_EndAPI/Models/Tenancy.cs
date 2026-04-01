using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Tenancy
{
    public int TenancyId { get; set; }

    public int CustomerId { get; set; }

    public int RoomId { get; set; }

    public int? ReservationId { get; set; }

    public DateOnly? CheckIn { get; set; }

    public virtual Customer1 Customer { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Reservation? Reservation { get; set; }

    public virtual Room Room { get; set; } = null!;
}
