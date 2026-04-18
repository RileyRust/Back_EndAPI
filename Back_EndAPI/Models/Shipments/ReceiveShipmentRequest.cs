using System.ComponentModel.DataAnnotations;

namespace Back_EndAPI.Models.Shipments
{
    public class ReceiveShipmentRequest
    {
        [Required]
        public int ShipmentId { get; set; }

        [Required]
        public List<ReceivedItemDto> Items { get; set; } = new();
    }

    public class ReceivedItemDto
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
