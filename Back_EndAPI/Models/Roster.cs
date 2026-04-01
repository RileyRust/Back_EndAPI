using System;
using System.Collections.Generic;

namespace Back_EndAPI.Models;

public partial class Roster
{
    public int Id { get; set; }

    public int PlayerId { get; set; }

    public int TeamId { get; set; }

    public int SeasonId { get; set; }

    public decimal SalaryAmount { get; set; }

    public virtual Player1 Player { get; set; } = null!;

    public virtual Season Season { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
