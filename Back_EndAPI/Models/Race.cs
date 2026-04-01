using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Race
{
    public int Id { get; set; }

    public DateTime? StartTime { get; set; }

    public int? TrackId { get; set; }

    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();

    public virtual Track? Track { get; set; }
}
