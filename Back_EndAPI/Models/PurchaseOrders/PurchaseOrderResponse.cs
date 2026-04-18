namespace Back_EndAPI.Models.PurchaseOrders;

public class PurchaseOrderResponse
{
    public int Id { get; set; }
    public DateOnly DateOrdered { get; set; }

    public int VendorId { get; set; }
    public string Status { get; set; } = "CREATED";
    public decimal? ExpectedTotalCost { get; set; }

    public List<OrderedItemResponse> Items { get; set; } = new();
}
