using Back_EndAPI.Data;
using Back_EndAPI.Entities;
using Back_EndAPI.Models.Shipments;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Services
{
    public class ShipmentService
    {
        private readonly AppDbContext _context;

        public ShipmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task ReceiveShipmentAsync(ReceiveShipmentRequest request)
        {
            var shipment = await _context.ReceivedShipments
                .FirstOrDefaultAsync(s => s.Id == request.ShipmentId);

            if (shipment == null)
                throw new Exception("Shipment does not exist.");

            foreach (var itemDto in request.Items)
            {
                if (itemDto.QuantityReceived <= 0)
                    throw new Exception("Invalid quantity received.");


                var bin = await _context.Bins
                    .FirstOrDefaultAsync(b => b.SkuNumber == itemDto.SkuNumber);

                if (bin == null)
                    throw new Exception($"No bin found for SKU {itemDto.SkuNumber}.");


                bin.Qtystored = (bin.Qtystored ?? 0) + itemDto.QuantityReceived;


                var receivedItem = new ReceivedItem
                {
                    SkuNumber = itemDto.SkuNumber,
                    ShipmentId = shipment.Id,
                    Qty = itemDto.QuantityReceived
                };

                _context.ReceivedItems.Add(receivedItem);

                await _context.SaveChangesAsync(); 
                var history = new ReceivedHistory
                {
                    ReceivedItemId = receivedItem.Id,
                    Qty = itemDto.QuantityReceived,
                    Comment = "Received during shipment processing"
                };

                _context.ReceivedHistories.Add(history);
            }

            await _context.SaveChangesAsync();
        }
    }
}
