using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Character
{
    public int CharacterId { get; set; }

    public string Name { get; set; } = null!;

    public string Class { get; set; } = null!;

    public int Level { get; set; }

    public int Health { get; set; }

    public int Mana { get; set; }
}
