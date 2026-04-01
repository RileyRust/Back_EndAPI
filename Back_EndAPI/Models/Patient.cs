using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string? InsuranceProvider { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
