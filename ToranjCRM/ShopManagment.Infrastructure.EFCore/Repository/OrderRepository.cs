using Microsoft.EntityFrameworkCore;
using ProjectFramework.Infrastructure;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderRepository : RepositoryBase<long, Order>, IOrderRepository
    {
        private readonly ShopContext _context;

        public OrderRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditOrder GetDetails(long id)
        {
            return _context.Orders.Select(x => new EditOrder
            {
                Id = x.Id,
                OrderStatus = x.OrderStatus,
                Code = x.Id.ToString(),
                Discount = x.Discount,
                DiscountRate = x.DiscountRate,
                EstimatedDeliveryDate = x.EstimatedDeliveryDate,
                DeliveredDate = x.DeliveredDate,
                Deposit = x.Deposit,
                FinallyPrice = x.FinallyPrice,
                Description = x.Description,
                CustomerId = x.CustomerId

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<OrderViewModel> Search(OrderSearchModel searchModel)
        {
            var query = _context.Orders.Include(x => x.Customer).Select(x => new OrderViewModel
            {
                Id = x.Id,
                Code = x.Id.ToString(),
                OrderStatus = x.OrderStatus,
                Discount = x.Discount,
                EstimatedDeliveryDate = x.EstimatedDeliveryDate,
                DeliveredDate = x.DeliveredDate,
                Deposit = x.Deposit,
                FinallyPrice = x.FinallyPrice,
                Description = x.Description,
                CustomerName = x.Customer.Name,
                CustomerPhoneNumber = x.Customer.PhoneNumber,
                CustomerId = x.CustomerId,
            });


            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));
            
            if (!string.IsNullOrWhiteSpace(searchModel.OrderStatus))
                query = query.Where(x => x.OrderStatus.Contains(searchModel.OrderStatus));

            if (!string.IsNullOrWhiteSpace(searchModel.CustomerName))
                query = query.Where(x => x.CustomerName.Contains(searchModel.CustomerName));

            if (!string.IsNullOrWhiteSpace(searchModel.CustomrPhoneNumber))
                query = query.Where(x => x.CustomerPhoneNumber.Contains(searchModel.CustomrPhoneNumber));

            if (searchModel.CompanyId != 0)
                query = query.Where(x => x.CompanyId == searchModel.CompanyId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
