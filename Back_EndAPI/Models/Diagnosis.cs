using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Diagnosis
{
    public int DiagnosisId { get; set; }

    public string? Code { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<AppointmentDiagnosis> AppointmentDiagnoses { get; set; } = new List<AppointmentDiagnosis>();
}
