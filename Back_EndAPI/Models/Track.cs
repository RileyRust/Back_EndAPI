using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Track
{
    public int Id { get; set; }

    public string? City { get; set; }

    public decimal? ElevationKm { get; set; }

    public decimal? LengthKm { get; set; }

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();
}
