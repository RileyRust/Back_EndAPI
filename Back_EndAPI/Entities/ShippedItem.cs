using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("shipped_item", Schema = "Team2Part2")]
public partial class ShippedItem
{
    [Column("box_tracking")]
    public int BoxTracking { get; set; }

    [Column("sku_number")]
    public int SkuNumber { get; set; }

    [Column("qty")]
    public int Qty { get; set; }

    [ForeignKey("BoxTracking")]
    [InverseProperty("ShippedItems")]
    public virtual Box? BoxTrackingNavigation { get; set; }

    [ForeignKey("SkuNumber")]
    [InverseProperty("ShippedItems")]
    public virtual Item? SkuNumberNavigation { get; set; }
}

