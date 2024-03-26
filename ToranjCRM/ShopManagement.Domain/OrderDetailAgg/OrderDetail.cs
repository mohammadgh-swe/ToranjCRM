using ProjectFramework.Domain;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.OrderDetailAgg
{
    public class OrderDetail : BaseEntity
    {
        public int Count { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public OrderDetail(long orderId, long productId, int count)
        {
            OrderId = orderId;
            ProductId = productId;
            Count = count;
        }

        public void Edit(long orderId, long productId, int count)
        {
            OrderId = orderId;
            ProductId = productId;
            Count = count;
        }

    }
}
