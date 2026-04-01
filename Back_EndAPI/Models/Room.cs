using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string? RoomNumber { get; set; }

    public int? Floor { get; set; }

    public int RoomTypeId { get; set; }

    public virtual ICollection<Tenancy> Tenancies { get; set; } = new List<Tenancy>();
}
