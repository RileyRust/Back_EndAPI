using Back_EndAPI.Data;
using Back_EndAPI.Entities;
using Back_EndAPI.Models.PurchaseOrders;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Services;

public class PurchaseOrderService
{
    private readonly AppDbContext _context;
    public PurchaseOrderService(AppDbContext context) => _context = context;

    public async Task<PurchaseOrderResponse> CreateAsync(CreatePurchaseOrderRequest request)
    {
        if (request.Items == null || !request.Items.Any())
            throw new InvalidOperationException("Purchase order must contain one or more items.");

        if (request.Items.Any(i => i.Quantity <= 0))
            throw new InvalidOperationException("Quantities must be greater than zero.");

        var vendorExists = await _context.Vendors.AnyAsync(v => v.Id == request.VendorId);
        if (!vendorExists)
            throw new KeyNotFoundException("Vendor not found.");

        var po = new PurchaseOrder
        {
            DateOrdered = request.DateOrdered,
            VendorId = request.VendorId
        };

        _context.PurchaseOrders.Add(po);
        await _context.SaveChangesAsync(); // generates po.Id

        foreach (var item in request.Items)
        {
            var orderedItem = new OrderedItem
            {
                PurchaseId = po.Id,
                SkuNumber = item.ProductId,
                Qty = item.Quantity
            };

            _context.OrderedItems.Add(orderedItem);
        }

        await _context.SaveChangesAsync();

        return new PurchaseOrderResponse
        {
            Id = po.Id,
            DateOrdered = po.DateOrdered,
            VendorId = po.VendorId,
            ExpectedTotalCost = request.ExpectedTotalCost,
            Status = "CREATED"
        };
    }

    public async Task<PurchaseOrderResponse?> GetByIdAsync(int id)
    {
        var po = await _context.PurchaseOrders
            .FirstOrDefaultAsync(p => p.Id == id);

        if (po == null)
            return null;

        // Load ordered items manually
        var items = await _context.OrderedItems
            .Where(i => i.PurchaseId == po.Id)
            .ToListAsync();

        return new PurchaseOrderResponse
        {
            Id = po.Id,
            DateOrdered = po.DateOrdered,
            VendorId = po.VendorId,
            Status = "CREATED",
            Items = items.Select(i => new OrderedItemResponse
            {
                ProductId = i.SkuNumber,
                Quantity = i.Qty
            }).ToList()
        };
    }
}
