using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ProjectFramework.Application;
using ProjectFramework.Infrastructure;
using ShopManagement.Infrastructure.EFCore;

namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _InventoryContext;
        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext) : base(inventoryContext)
        {
            _InventoryContext = inventoryContext;
            _shopContext = shopContext;
        }

        public EditInventory GetDetails(long id)
        {
            return _InventoryContext.Inventory.Select(x => new EditInventory
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                ProductId = x.ProductId

            }).FirstOrDefault(x => x.Id == id);
        }

        public Inventory GetBy(long productId)
        {
            return _InventoryContext.Inventory.FirstOrDefault(x => x.ProductId == productId);
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _InventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                InStock = x.InStock,
                ProductId = x.ProductId,
                CurrentCount = x.CalculateCurrentCount(),
                CreationDate = x.CreateAt.ToFarsi()
            });

            if (searchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (searchModel.InStock)
                query = query.Where(x => !x.InStock);


            var inventory = query.OrderByDescending(x => x.Id).ToList();

            inventory.ForEach(item =>
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name);

            return inventory;
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            var inventory = _InventoryContext.Inventory.FirstOrDefault(x => x.Id == inventoryId);
            return inventory.Operations.Select(x => new InventoryOperationViewModel
            {
                Id = x.InventoryId,
                Count = x.Count,
                Description = x.Description,
                CurrentCount = x.CurrentCount,
                Operation = x.Operation,
                OperationDate = x.OperationDate.ToFarsi(),
                OperatorId = x.OperatorId,
                OperatorName = "مدیر سیستم",
                OrderId = x.OrderId

            }).ToList();

        }
    }
}
