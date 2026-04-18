using System.ComponentModel.DataAnnotations;

namespace Back_EndAPI.Models.PurchaseOrders
{
    public class PurchaseOrderItemDto
    {
        public int ProductId { get; set; }   
        public int Quantity { get; set; }   
    }
  

    public class CreatePurchaseOrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class CreatePurchaseOrderRequest
    {
        public DateOnly DateOrdered { get; set; }
        public int VendorId { get; set; }
        public decimal ExpectedTotalCost { get; set; }
        public List<CreatePurchaseOrderItemDto> Items { get; set; } = new();
    }

    public class OrderedItemResponse
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
