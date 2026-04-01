using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Season
{
    public int Id { get; set; }

    public int SeasonName { get; set; }

    public DateOnly SeasonStartDate { get; set; }

    public DateOnly SeasonEndDate { get; set; }

    public virtual ICollection<Roster> Rosters { get; set; } = new List<Roster>();
}
