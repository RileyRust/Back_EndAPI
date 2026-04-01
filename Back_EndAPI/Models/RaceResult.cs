using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class RaceResult
{
    public int Id { get; set; }

    public int? DriverId { get; set; }

    public int? FinishPosition { get; set; }

    public int? NumLapsFinished { get; set; }

    public int? RaceId { get; set; }

    public decimal? TotalRaceTimeSeconds { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Race? Race { get; set; }
}
