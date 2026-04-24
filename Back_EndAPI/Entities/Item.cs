using Back_EndAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("item", Schema = "Team2Part2")]
public partial class Item
{
    [Key]
    [Column("sku_number")]
    public int SkuNumber { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("suggested_selling_price")]
    [Precision(10, 2)]
    public decimal? SuggestedSellingPrice { get; set; }

    [Column("volume_per_unit")]
    public int? VolumePerUnit { get; set; }

    public virtual ICollection<Bin> Bins { get; set; } = new List<Bin>();

    public virtual ICollection<ReceivedItem> ReceivedItems { get; set; } = new List<ReceivedItem>();

    public virtual ICollection<ShippedItem> ShippedItems { get; set; } = new List<ShippedItem>();
}
