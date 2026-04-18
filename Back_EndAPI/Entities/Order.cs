using System.ComponentModel.DataAnnotations.Schema;

[Table("customer_order", Schema = "Team2Part2")]
public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateOnly DateOrdered { get; set; }
    public string NameOrdered { get; set; }
    public decimal CustomerShippingFee { get; set; }
}
