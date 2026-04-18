using System.ComponentModel.DataAnnotations.Schema;

[Table("ordered_item", Schema = "Team2Part2")]
public class OrderedItem
{
    public int Id { get; set; }
    public int PurchaseId { get; set; }
    public int SkuNumber { get; set; }
    public int Qty { get; set; }
    public decimal CostPerUnit { get; set; }
}
