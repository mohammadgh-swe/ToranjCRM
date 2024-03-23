using ProjectFramework.Domain;

namespace ShopManagement.Domain.OrderAgg
{
    public class Order : BaseEntity
    {
        public string Code { get; private set; }
        public string OrderStatus { get; private set; }
        public double Discount { get; private set; }
        public float DiscountRate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public DateTime DeliveredDate { get; private set; }
        public double Deposit { get; private set; }
        public double TotalPrice { get; private set; }
        public double FinallyPrice { get; private set; }
        public string Description { get; set; }
        public long OperatorId { get; private set; }
        public bool Finally { get; private set; }
    }
}
