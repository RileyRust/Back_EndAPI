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
                .Include(s => s.ReceivedItems)
                .FirstOrDefaultAsync(s => s.Id == request.ShipmentId);

            if (shipment == null)
                throw new KeyNotFoundException("Shipment not found.");

     
            if (shipment.ReceivedItems.Any())
                throw new InvalidOperationException("Shipment has already been received.");


            foreach (var itemDto in request.Items)
            {
                if (itemDto.QuantityReceived <= 0)
                    throw new Exception("Invalid quantity received.");

                var bin = await _context.Bins
                    .FirstOrDefaultAsync(b => b.SkuNumber == itemDto.SkuNumber);

                if (bin == null)
                    throw new Exception($"No bin found for SKU {itemDto.SkuNumber}.");

                // Update inventory
                bin.Qtystored = (bin.Qtystored ?? 0) + itemDto.QuantityReceived;

                // Insert ReceivedItem
                var receivedItem = new ReceivedItem
                {
                    SkuNumber = itemDto.SkuNumber,
                    ShipmentId = shipment.Id,
                    Qty = itemDto.QuantityReceived
                };

                _context.ReceivedItems.Add(receivedItem);
                await _context.SaveChangesAsync(); // needed to get receivedItem.Id

                // Insert ReceivedHistory
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
