using Back_EndAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("box", Schema = "Team2Part2")]
public partial class Box
{
    [Key]
    [Column("tracking")]
    public int Tracking { get; set; }

    [Column("volume")]
    [Precision(10, 2)]
    public decimal? Volume { get; set; }

    [Column("carrier_shipping_fee")]
    [Precision(10, 2)]
    public decimal? CarrierShippingFee { get; set; }

    [Column("customer_order_id")]
    public int? CustomerOrderId { get; set; }

    [Column("date_shipped")]
    public DateOnly? DateShipped { get; set; }

    [ForeignKey("CustomerOrderId")]
    public Order? Order { get; set; }

    [InverseProperty("BoxTrackingNavigation")]
    public virtual ICollection<ShippedItem> ShippedItems { get; set; } = new List<ShippedItem>();
}
