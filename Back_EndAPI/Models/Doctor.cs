using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string Name { get; set; } = null!;

    public string Specialty { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Department Department { get; set; } = null!;
}
