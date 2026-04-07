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
            var po = new PurchaseOrder
            {
                DateOrdered = request.DateOrdered,
                Vendorid = request.VendorId,
                ExpectedTotalCost = request.ExpectedTotalCost
            };

            _context.PurchaseOrders.Add(po);
            await _context.SaveChangesAsync();

            return po;
        }

    }
}
