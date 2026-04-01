using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Date1
{
    public int DateId { get; set; }

    public DateOnly CalendarDate { get; set; }

    public string? DayOfWeek { get; set; }

    public virtual ICollection<Reservation> ReservationEndDates { get; set; } = new List<Reservation>();

    public virtual ICollection<Reservation> ReservationStartDates { get; set; } = new List<Reservation>();
}
