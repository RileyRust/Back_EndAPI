using System.ComponentModel.DataAnnotations.Schema;

namespace Back_EndAPI.Entities;

[Table("sold_item", Schema = "Team2Part2")]
public class SoldItem
{
    [Column("sku_number")]
    public int SkuNumber { get; set; }

    [Column("customer_order_id")]
    public int CustomerOrderId { get; set; }

    [Column("qty")]
    public int Qty { get; set; }
}
