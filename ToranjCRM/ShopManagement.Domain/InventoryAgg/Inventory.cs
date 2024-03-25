using ProjectFramework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.InventoryAgg
{
    public class Inventory : BaseEntity
    {
        public long ProductId { get; private set; }
        public Product Product { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }

        public Inventory()
        {
            Operations = new List<InventoryOperation>();
        }

        public Inventory(long productId, DateTime creationDate)
        {
            ProductId = productId;
            InStock = false;
            CreateAt = creationDate;
        }

        public long CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }

        public void Increase(long count, long operatorId, string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(true, count, operatorId, currentCount, description, 0, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }

        public void Decrease(long count, long operatorId, string description, long orderId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(false, count, operatorId, currentCount, description, orderId, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }

    }
}
