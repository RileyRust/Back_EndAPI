using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class AppointmentTreatment
{
    public int AppointmentId { get; set; }

    public int TreatmentId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitCostAtTime { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;

    public virtual Treatment Treatment { get; set; } = null!;
}
