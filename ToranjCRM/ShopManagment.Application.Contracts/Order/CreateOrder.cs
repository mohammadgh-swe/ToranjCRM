namespace ShopManagement.Application.Contracts.Order
{
    public class CreateOrder
    {
        public string Code { get;  set; }
        public string OrderStatus { get; set; } = "سایز گیری";
        public double Discount { get; set; } = 0;
        public float DiscountRate { get; set; } = 0;
        public DateTime EstimatedDeliveryDate { get; set; } = DateTime.Now.AddDays(30);
        public DateTime? DeliveredDate { get; set; } = DateTime.MaxValue;
        public double Deposit { get; set; } = 0;
        public double FinallyPrice { get; set; } = 0;
        public string? Description { get; set; }
        //requierd
        public long CustomerId { get; set; }
    }
}
