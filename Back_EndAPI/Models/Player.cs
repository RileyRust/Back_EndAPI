using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public int GameId { get; set; }

    public string Name { get; set; } = null!;

    public int Cash { get; set; }

    public int BoardPosition { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual JailStatus? JailStatus { get; set; }

    public virtual ICollection<PropertyOwnership> PropertyOwnerships { get; set; } = new List<PropertyOwnership>();
}
