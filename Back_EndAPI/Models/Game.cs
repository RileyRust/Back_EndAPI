using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Game
{
    public int GameId { get; set; }

    public int? CurrentPlayerId { get; set; }

    public int TurnNumber { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
