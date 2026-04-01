using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Treatment
{
    public int TreatmentId { get; set; }

    public string Description { get; set; } = null!;

    public decimal StandardCost { get; set; }

    public virtual ICollection<AppointmentTreatment> AppointmentTreatments { get; set; } = new List<AppointmentTreatment>();
}
