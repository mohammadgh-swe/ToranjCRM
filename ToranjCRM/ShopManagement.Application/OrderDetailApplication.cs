using ProjectFramework.Application;
using ShopManagement.Application.Contracts.OrderDetail;
using ShopManagement.Domain.OrderDetailAgg;

namespace ShopManagement.Application
{
    public class OrderDetailApplication : IOrderDetailApplication
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailApplication(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public OperationResult Create(CreateOrderDetail command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditOrderDetail command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Remove(long id)
        {
            throw new NotImplementedException();
        }

        public EditOrderDetail GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetailViewModel> Search(OrderDetailSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
