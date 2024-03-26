using Microsoft.EntityFrameworkCore;
using ProjectFramework.Application;
using ProjectFramework.Infrastructure;
using ShopManagement.Application.Contracts.OrderDetail;
using ShopManagement.Domain.OrderDetailAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderDetailRepository : RepositoryBase<long, OrderDetail>, IOrderDetailRepository
    {
        private readonly ShopContext _context;

        public OrderDetailRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public void Remove(OrderDetail orderDetail)
        {

            _context.OrderDetails.Remove(orderDetail);
        }

        public EditOrderDetail GetDetails(long id)
        {
            return _context.OrderDetails.Select(x => new EditOrderDetail
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Count = x.Count
                
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<OrderDetailViewModel> Search(OrderDetailSearchModel searchModel)
        {
            var query = _context.OrderDetails
                .Include(x => x.Product)
                .Include(x => x.Order)
                .Select(x => new OrderDetailViewModel
            {
                Id = x.Id,
                OrderCode = x.Order.Code,
                Product = x.Product.Name,
                ProductCode = x.Product.Code,
                UnitPrice = x.Product.UnitPrice,
                Size = x.Product.Size,
                count = x.Count
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Product))
                query = query.Where(x => x.Product.Contains(searchModel.Product));
            if (!string.IsNullOrWhiteSpace(searchModel.ProductCode))
                query = query.Where(x => x.ProductCode.Contains(searchModel.ProductCode));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
