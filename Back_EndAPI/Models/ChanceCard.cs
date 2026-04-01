using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class ChanceCard
{
    public int CardId { get; set; }

    public string Description { get; set; } = null!;
}
