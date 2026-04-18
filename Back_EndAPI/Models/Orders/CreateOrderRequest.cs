// Models/Orders/CreateOrderRequest.cs
namespace Back_EndAPI.Models.Orders;

public class CreateOrderItemDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class CreateOrderRequest
{
    public List<CreateOrderItemDto> Items { get; set; } = new();
}

public class OrderLineResponse
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class OrderResponse
{
    public int Id { get; set; }
    public string Status { get; set; } = "CREATED";
    public List<OrderLineResponse> Items { get; set; } = new();
}
