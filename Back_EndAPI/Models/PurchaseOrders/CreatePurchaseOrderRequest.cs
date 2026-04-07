using System.ComponentModel.DataAnnotations;

namespace Back_EndAPI.Models.PurchaseOrders
{
    public class CreatePurchaseOrderRequest
    {
        [Required]
        public DateOnly DateOrdered { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Range(0, int.MaxValue)]
        public int ExpectedTotalCost { get; set; }
    }
}
