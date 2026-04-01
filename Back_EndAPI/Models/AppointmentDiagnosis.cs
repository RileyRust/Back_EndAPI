using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class AppointmentDiagnosis
{
    public int AppointmentId { get; set; }

    public int DiagnosisId { get; set; }

    public string? Notes { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;

    public virtual Diagnosis Diagnosis { get; set; } = null!;
}
