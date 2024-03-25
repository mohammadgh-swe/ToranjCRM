using ProjectFramework.Domain;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.OrderDetailsAgg
{
    public class OrderDetail : BaseEntity
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public OrderDetail(long orderId, long productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }

        public void Edit(long orderId, long productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
