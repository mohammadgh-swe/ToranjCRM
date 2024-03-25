namespace ShopManagement.Application.Contracts.Inventory;

public class InventorySearchModel
{

    public string? ProductName { get; set; }
    public string? ProductCode { get; set; }
    public long CategoryId { get; set; }
    public long CompanyId { get; set; }
    public bool InStock { get; set; }
}
