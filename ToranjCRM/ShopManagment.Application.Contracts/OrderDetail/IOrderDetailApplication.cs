using ProjectFramework.Application;

namespace ShopManagement.Application.Contracts.OrderDetail
{
    public interface IOrderDetailApplication
    {
        OperationResult Create(CreateOrderDetail command);
        OperationResult Edit(EditOrderDetail command);
        OperationResult Remove(long id);
        EditOrderDetail GetDetails(long id);
        List<OrderDetailViewModel> Search(OrderDetailSearchModel searchModel);
    }
}
