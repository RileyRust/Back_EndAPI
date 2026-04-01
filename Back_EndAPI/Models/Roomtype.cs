using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Roomtype
{
    public int RoomTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public decimal? NightlyRate { get; set; }

    public int? MaxOccupancy { get; set; }
}
