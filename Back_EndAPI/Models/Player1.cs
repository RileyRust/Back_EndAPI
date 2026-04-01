using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Player1
{
    public int Id { get; set; }

    public string PlayerName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Roster> Rosters { get; set; } = new List<Roster>();
}
