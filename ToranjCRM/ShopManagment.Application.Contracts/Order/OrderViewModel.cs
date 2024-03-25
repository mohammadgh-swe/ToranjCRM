namespace ShopManagement.Application.Contracts.Order;

public class OrderViewModel
{
    public long Id { get; set; }
    public string Code { get; set; }
    public string OrderStatus { get; set; }
    public double Discount { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }
    public DateTime DeliveredDate { get; set; }
    public double Deposit { get; set; }
    public double FinallyPrice { get; set; }
    public string Description { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public long CustomerId { get; set; }
    public long CompanyId { get; set; }
}