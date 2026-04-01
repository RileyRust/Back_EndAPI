using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Team
{
    public int Id { get; set; }

    public string TeamName { get; set; } = null!;

    public string? City { get; set; }

    public virtual ICollection<Roster> Rosters { get; set; } = new List<Roster>();
}
