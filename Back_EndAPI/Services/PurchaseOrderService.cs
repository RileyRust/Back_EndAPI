using Back_EndAPI.Data;
using Back_EndAPI.Entities;
using Back_EndAPI.Models.PurchaseOrders;

namespace Back_EndAPI.Services
{
    public class PurchaseOrderService
    {
        private readonly AppDbContext _context;

        public PurchaseOrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PurchaseOrder> CreateAsync(CreatePurchaseOrderRequest request)
        {
     
            if (request.Items == null || !request.Items.Any())
                throw new InvalidOperationException("Purchase order must contain at least one item.");

  
            foreach (var item in request.Items)
            {
                if (item.ProductId <= 0)
                    throw new InvalidOperationException("Each item must include a valid productId.");

                if (item.Quantity <= 0)
                    throw new InvalidOperationException("Quantity must be greater than 0.");
            }

      
            var po = new PurchaseOrder
            {
                DateOrdered = request.DateOrdered,
                Vendorid = request.VendorId,
                ExpectedTotalCost = request.ExpectedTotalCost
            
            };

            _context.PurchaseOrders.Add(po);
            await _context.SaveChangesAsync();


            foreach (var item in request.Items)
            {
                var orderedItem = new OrderedItem
                {
                    PurchaseId = po.Id,         
                    SkuNumber = item.ProductId, 
                    Qty = item.Quantity,        
                    CostPerUnit = 0             
                };

                _context.OrderedItems.Add(orderedItem);
            }

            await _context.SaveChangesAsync();

            return po;
        }



    }
}
