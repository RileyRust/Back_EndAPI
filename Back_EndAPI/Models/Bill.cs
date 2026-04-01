using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int PatientId { get; set; }

    public int AppointmentId { get; set; }

    public decimal TotalAmount { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public virtual Appointment Appointment { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual ICollection<Payment1> Payment1s { get; set; } = new List<Payment1>();
}
