using Back_EndAPI.Data;
using Back_EndAPI.Entities;
using Back_EndAPI.Models.Shipments;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Services;

public class ShipmentService
{
    private readonly AppDbContext _context;
    public ShipmentService(AppDbContext context) => _context = context;

    public async Task<int> CreateAsync(CreateShipmentRequest request)
    {
        var po = await _context.PurchaseOrders.FindAsync(request.PurchaseOrderId)
                 ?? throw new KeyNotFoundException("Purchase order not found.");

        var shipment = new ReceivedShipment
        {
            PurchaseOrderId = po.Id,
            Date = request.Date
        };

        _context.ReceivedShipments.Add(shipment);
        await _context.SaveChangesAsync();
        return shipment.Id;
    }

    public async Task ReceiveAsync(int shipmentId, ReceiveShipmentRequest request)
    {
        var shipment = await _context.ReceivedShipments
     .FirstOrDefaultAsync(s => s.Id == shipmentId)
     ?? throw new KeyNotFoundException("Shipment not found.");

        var existingItems = await _context.ReceivedItems
            .Where(i => i.ShipmentId == shipment.Id)
            .ToListAsync();

        if (existingItems.Any())
            return;


        if (request.Items == null || !request.Items.Any())
            throw new InvalidOperationException("Shipment must contain one or more items.");

        if (request.Items.Any(i => i.Quantity <= 0))
            throw new InvalidOperationException("Quantities must be greater than zero.");

        using var tx = await _context.Database.BeginTransactionAsync();

        foreach (var item in request.Items)
        {
            var productExists = await _context.Items.AnyAsync(i => i.SkuNumber
 == item.ProductId);
            if (!productExists) throw new KeyNotFoundException($"Product {item.ProductId} not found.");

            var receivedItem = new ReceivedItem
            {
                SkuNumber = item.ProductId,
                ShipmentId = shipment.Id,
                Qty = item.Quantity
            };
            _context.ReceivedItems.Add(receivedItem);

            var bin = await _context.Bins.FirstOrDefaultAsync(b => b.SkuNumber == item.ProductId);
            if (bin == null)
                throw new InvalidOperationException($"No bin configured for product {item.ProductId}.");

            bin.Qtystored = (bin.Qtystored ?? 0) + item.Quantity;
        }

        await _context.SaveChangesAsync();
        await tx.CommitAsync();
    }
}
