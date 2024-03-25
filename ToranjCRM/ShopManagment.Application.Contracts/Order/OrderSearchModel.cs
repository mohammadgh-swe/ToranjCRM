namespace ShopManagement.Application.Contracts.Order;

public class OrderSearchModel
{
    public string Code { get; set; }
    public string OrderStatus { get; set; }
    public string CustomerName { get; set; }
    public string CustomrPhoneNumber{ get; set; }
    public long CompanyId { get; set; }
}