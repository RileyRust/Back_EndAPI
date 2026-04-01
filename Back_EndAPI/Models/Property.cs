using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Property
{
    public int PropertyId { get; set; }

    public string Name { get; set; } = null!;

    public int? NeighborhoodId { get; set; }

    public int BaseRent { get; set; }

    public virtual Neighborhood? Neighborhood { get; set; }

    public virtual PropertyOwnership? PropertyOwnership { get; set; }
}
