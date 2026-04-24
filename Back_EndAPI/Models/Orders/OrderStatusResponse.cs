namespace Back_EndAPI.Models.Orders
{
    public class OrderItemResponse
    {
        public int ProductId { get; set; }
        public string Sku { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderStatusResponse
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string TrackingNumber { get; set; }
        public List<OrderItemResponse> Items { get; set; }
    }
}
