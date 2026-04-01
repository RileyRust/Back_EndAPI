using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public DateTime AppointmentDatetime { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public string ReasonForVisit { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<AppointmentDiagnosis> AppointmentDiagnoses { get; set; } = new List<AppointmentDiagnosis>();

    public virtual ICollection<AppointmentTreatment> AppointmentTreatments { get; set; } = new List<AppointmentTreatment>();

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
