using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class PropertyOwnership
{
    public int PropertyId { get; set; }

    public int PlayerId { get; set; }

    public int BuildingCount { get; set; }

    public virtual Player Player { get; set; } = null!;

    public virtual Property Property { get; set; } = null!;
}
