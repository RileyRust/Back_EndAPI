using Back_EndAPI.Data;
using Back_EndAPI.Models.Inventory;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Services;

public class InventoryService
{
    private readonly AppDbContext _context;
    public InventoryService(AppDbContext context) => _context = context;

    public async Task<InventoryResponse> StoreAsync(StoreInventoryRequest request)
    {
        if (request.Quantity <= 0)
            throw new InvalidOperationException("Quantity must be greater than zero.");

        var product = await _context.Items.FindAsync(request.ProductId)
                      ?? throw new KeyNotFoundException("Product not found.");

        var bin = await _context.Bins.FindAsync(request.BinId)
                  ?? throw new KeyNotFoundException("Bin not found.");

        if (bin.SkuNumber != null && bin.SkuNumber != request.ProductId)
            throw new InvalidOperationException("Bin already assigned to a different product.");

        bin.SkuNumber = request.ProductId;
        bin.Qtystored = (bin.Qtystored ?? 0) + request.Quantity;

        await _context.SaveChangesAsync();

        return new InventoryResponse
        {
            ProductId = request.ProductId,
            BinId = request.BinId,
            Quantity = bin.Qtystored ?? 0
        };
    }
}
