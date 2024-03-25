namespace ShopManagement.Application.Contracts.Inventory;

public class InventoryViewModel
{
    public long Id { get; set; }
    public string Product { get; set; }
    public long ProductId { get; set; }
    public string ProductCode { get; set; }
    public string Company { get; set; }
    public long CompanyId { get; set; }
    public string Category { get; set; }
    public long CategoryId { get; set; }
    public bool InStock { get; set; }
    public long CurrentCount { get; set; }
    public string CreationDate { get; set; }
}