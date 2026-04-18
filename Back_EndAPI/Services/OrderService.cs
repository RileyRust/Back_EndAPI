using Back_EndAPI.Data;
using Back_EndAPI.Entities;
using Back_EndAPI.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Services;

public class OrderService
{
    private readonly AppDbContext _context;
    public OrderService(AppDbContext context) => _context = context;

    public async Task<OrderResponse> CreateAsync(CreateOrderRequest request)
    {
        if (request.Items == null || !request.Items.Any())
            throw new InvalidOperationException("Order must contain one or more items.");

        if (request.Items.Any(i => i.Quantity <= 0))
            throw new InvalidOperationException("Quantities must be greater than zero.");

    
        var newOrder = new Order
        {
            DateOrdered = DateOnly.FromDateTime(DateTime.UtcNow)

        };

        _context.Orders.Add(newOrder);
        await _context.SaveChangesAsync();  

  
        foreach (var item in request.Items)
        {
            var product = await _context.Items
                .FirstOrDefaultAsync(i => i.SkuNumber == item.ProductId);

            if (product == null)
                throw new InvalidOperationException($"Product {item.ProductId} does not exist.");

            _context.OrderLines.Add(new OrderLine
            {
                CustomerOrderId = newOrder.Id,  
                SkuNumber = item.ProductId,
                Qty = item.Quantity
            });
        }

        await _context.SaveChangesAsync();

        // 3️⃣ Return mapped response
        return await MapAsync(newOrder.Id);
    }


    public async Task<OrderResponse> PickAsync(int orderId)
    {
      
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == orderId)
            ?? throw new KeyNotFoundException("Order not found.");

   
        var lines = await _context.OrderLines
            .Where(l => l.CustomerOrderId == order.Id)
            .ToListAsync();

        if (lines.Count == 0)
            throw new InvalidOperationException("Order has no lines.");

        using var tx = await _context.Database.BeginTransactionAsync();

        foreach (var line in lines)
        {
            var bin = await _context.Bins
                .FirstOrDefaultAsync(b => b.SkuNumber == line.SkuNumber);

            if (bin == null || (bin.Qtystored ?? 0) < line.Qty)
                throw new InvalidOperationException(
                    $"Insufficient inventory for SKU {line.SkuNumber}.");

            bin.Qtystored -= line.Qty;

            if (bin.Qtystored < 0)
                throw new InvalidOperationException("Inventory cannot be negative.");
        }

        await _context.SaveChangesAsync();
        await tx.CommitAsync();

        return await MapAsync(order.Id);
    }

    public async Task<OrderResponse> PackAsync(int orderId)
    {
   
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == orderId)
            ?? throw new KeyNotFoundException("Order not found.");

 
        var lines = await _context.OrderLines
            .Where(l => l.CustomerOrderId == order.Id)
            .ToListAsync();

        if (lines.Count == 0)
            throw new InvalidOperationException("Order has no items to pack.");
        return await MapAsync(order.Id);
    }


    public async Task<OrderResponse> ShipAsync(int orderId)
    {
 
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == orderId)
            ?? throw new KeyNotFoundException("Order not found.");

        var lines = await _context.OrderLines
            .Where(l => l.CustomerOrderId == order.Id)
            .ToListAsync();

        if (lines.Count == 0)
            throw new InvalidOperationException("Order has no items to ship.");

        return await MapAsync(order.Id);
    }


    private async Task<OrderResponse> MapAsync(int orderId)
    {
        var order = await _context.Orders
            .FirstAsync(o => o.Id == orderId);

     
        var lines = await _context.OrderLines
            .Where(l => l.CustomerOrderId == order.Id)
            .ToListAsync();

        return new OrderResponse
        {
            Id = order.Id,

         
            Status = null,

            Items = lines.Select(l => new OrderLineResponse
            {
                ProductId = l.SkuNumber,
                Quantity = l.Qty
            }).ToList()
        };
    }

    public async Task<OrderResponse?> GetByIdAsync(int id)
    {
       
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
            return null;

       
        var lines = await _context.OrderLines
            .Where(l => l.CustomerOrderId == order.Id)
            .ToListAsync();

        return new OrderResponse
        {
            Id = order.Id,

      
            Status = null,

            Items = lines.Select(l => new OrderLineResponse
            {
                ProductId = l.SkuNumber,
                Quantity = l.Qty
            }).ToList()
        };
    }


}
