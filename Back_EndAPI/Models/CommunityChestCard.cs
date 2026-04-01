using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class CommunityChestCard
{
    public int CardId { get; set; }

    public string Description { get; set; } = null!;
}
