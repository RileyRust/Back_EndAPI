using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int CustomerId { get; set; }

    public int RoomTypeId { get; set; }

    public int StartDateId { get; set; }

    public int EndDateId { get; set; }

    public virtual Customer1 Customer { get; set; } = null!;

    public virtual Date1 EndDate { get; set; } = null!;

    public virtual Date1 StartDate { get; set; } = null!;

    public virtual ICollection<Tenancy> Tenancies { get; set; } = new List<Tenancy>();
}
