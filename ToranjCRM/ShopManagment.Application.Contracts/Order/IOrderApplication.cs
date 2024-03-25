using ProjectFramework.Application;

namespace ShopManagement.Application.Contracts.Order
{
    public interface IOrderApplication
    {
        OperationResult Create(CreateOrder command);
        OperationResult Edit(EditOrder command);
        EditOrder GetDetails(long id);
        List<OrderViewModel> Search(OrderViewModel searchModel);
    }
}
