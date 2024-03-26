using ProjectFramework.Domain;
using ShopManagement.Domain.CustomerAgg;
using ShopManagement.Domain.OrderDetailAgg;

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
        public double FinallyPrice { get; private set; }
        public string Description { get; set; }

        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public Order(string code, string orderStatus, double discount,
            float discountRate, DateTime estimatedDeliveryDate,
            DateTime deliveredDate, double deposit, double finallyPrice,
            string description, long customerId)
        {
            Code = code;
            OrderStatus = orderStatus;
            Discount = discount;
            DiscountRate = discountRate;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            DeliveredDate = deliveredDate;
            Deposit = deposit;
            FinallyPrice = finallyPrice;
            Description = description;
            CustomerId = customerId;
        }

        public void Edit(string orderStatus, double discount, float discountRate,
            DateTime estimatedDeliveryDate, DateTime deliveredDate, double deposit,
            double finallyPrice, string description)
        {
            OrderStatus = orderStatus;
            Discount = discount;
            DiscountRate = discountRate;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            DeliveredDate = deliveredDate;
            Deposit = deposit;
            FinallyPrice = finallyPrice;
            Description = description;
        }
    }
}
