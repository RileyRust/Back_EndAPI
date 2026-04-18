namespace Back_EndAPI.Models.Shipments;

public class CreateShipmentRequest
{
    public int PurchaseOrderId { get; set; }
    public DateOnly Date { get; set; }
}

public class ReceiveShipmentItemDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class ReceiveShipmentItemsRequest
{
    public List<ReceiveShipmentItemDto> Items { get; set; } = new();
}
