namespace Back_EndAPI.Models.Inventory
{
    public class InventoryItemResponse
    {
        public int ProductId { get; set; }
        public string Sku { get; set; }
        public int TotalQuantity { get; set; }
        public List<InventoryBinResponse> Bins { get; set; }
    }

    public class InventoryBinResponse
    {
        public int BinId { get; set; }
        public int Quantity { get; set; }
    }

    public class InventoryListResponse
    {
        public List<InventoryItemResponse> Items { get; set; }
    }
}
