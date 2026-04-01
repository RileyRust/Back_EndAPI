using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Driver
{
    public int Id { get; set; }

    public DateOnly Birthdate { get; set; }

    public decimal? HeightCm { get; set; }

    public string? Name { get; set; }

    public decimal? WeightKg { get; set; }

    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();
}
