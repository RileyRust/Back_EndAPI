using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Neighborhood
{
    public int NeighborhoodId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
}
