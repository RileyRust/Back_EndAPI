using System.ComponentModel.DataAnnotations;

namespace Back_EndAPI.Models.PurchaseOrders
{
    public class CreatePurchaseOrderRequest
    {
        public DateOnly DateOrdered { get; set; }
        public int VendorId { get; set; }
        public int ExpectedTotalCost { get; set; }

        public List<PurchaseOrderItemDto> Items { get; set; } = new();
    }

    public class PurchaseOrderItemDto
    {
        public int ProductId { get; set; }   
        public int Quantity { get; set; }   
    }
}
