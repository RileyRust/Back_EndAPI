using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Employee1
{
    public Guid EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? JobTitle { get; set; }

    public decimal? Salary { get; set; }

    public DateOnly HireDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
