using Microsoft.EntityFrameworkCore;
using ProjectFramework.Application;
using ProjectFramework.Infrastructure;
using ShopManagement.Application.Contracts.Inventory;
using ShopManagement.Domain.InventoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly ShopContext _shopContext;
        private InventoryViewModel _ViewModel;

        public InventoryRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }
        public Inventory GetBy(long productId)
        {
            return _shopContext.Inventory.FirstOrDefault(x => x.ProductId == productId);
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new {x.Id, x.Name, x.Code, x.CategoryId,
                x.Category, x.CompanyId, x.Company });

            var query = _shopContext.Inventory.Include(x => x.Product)
                .Select(x => new InventoryViewModel
                {
                    Id = x.Id,
                    Product = x.Product.Name,
                    ProductCode = x.Product.Code,
                    ProductId = x.ProductId,
                    InStock = x.InStock,
                    Category = x.Product.Category.Name,
                    CategoryId = x.Product.CategoryId,
                    Company = x.Product.Company.Name,
                    CompanyId = x.Product.CompanyId,
                    CreationDate = x.CreateAt.Date.ToFarsi(),
                    CurrentCount = x.CalculateCurrentCount()
                });


            if (!string.IsNullOrWhiteSpace(searchModel.ProductName))
                query = query.Where(x => x.Product.Contains(searchModel.ProductName));

            if (!string.IsNullOrWhiteSpace(searchModel.ProductCode))
                query = query.Where(x => x.ProductCode.Contains(searchModel.ProductCode));

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            if (searchModel.CompanyId != 0)
                query = query.Where(x => x.CompanyId == searchModel.CompanyId);

            if (searchModel.InStock)
                query = query.Where(x => !x.InStock);

            var inventory = query.OrderByDescending(x => x.Id).ToList();

            return inventory;
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            var inventory = _shopContext.Inventory.FirstOrDefault(x => x.Id == inventoryId);
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
