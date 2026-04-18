// Models/Inventory/StoreInventoryRequest.cs
namespace Back_EndAPI.Models.Inventory;

public class StoreInventoryRequest
{
    public int ProductId { get; set; }
    public int BinId { get; set; }
    public int Quantity { get; set; }
}

public class InventoryResponse
{
    public int ProductId { get; set; }
    public int BinId { get; set; }
    public int Quantity { get; set; }
}
