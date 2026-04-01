using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class JailStatus
{
    public int PlayerId { get; set; }

    public string Status { get; set; } = null!;

    public int? TurnsAttempted { get; set; }

    public virtual Player Player { get; set; } = null!;
}
