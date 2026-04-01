using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Date
{
    public int DateId { get; set; }

    public DateOnly? CalendarDate { get; set; }

    public string? DayOfWeek { get; set; }
}
