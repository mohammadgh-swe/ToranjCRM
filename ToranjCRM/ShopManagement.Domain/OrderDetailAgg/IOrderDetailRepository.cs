using ProjectFramework.Application;
using ShopManagement.Application.Contracts.OrderDetail;

namespace ShopManagement.Domain.OrderDetailAgg
{
    public interface IOrderDetailRepository
    {
        void Remove(OrderDetail orderDetail);
        EditOrderDetail GetDetails(long id);
        List<OrderDetailViewModel> Search(OrderDetailSearchModel searchModel);
    }
}
