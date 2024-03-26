namespace ShopManagement.Application.Contracts.OrderDetail;

public class OrderDetailViewModel
{
    public long Id { get; set; }
    public string OrderCode { get; set; }
    public string OrderCreationDate { get; set; }
    public string Product { get; set; }
    public string ProductCode { get; set; }
    public string Size { get; set; }
    public double UnitPrice { get; set; }
    public int count { get; set; }
}