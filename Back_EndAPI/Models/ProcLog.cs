using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class ProcLog
{
    public int Id { get; set; }

    public DateTime? Tstamp { get; set; }

    public string? Comment { get; set; }
}
