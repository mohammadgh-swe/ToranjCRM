using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectFramework.Application;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderRepository _orderRepository;

        public OrderApplication(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public OperationResult Create(CreateOrder command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditOrder command)
        {
            throw new NotImplementedException();
        }

        public EditOrder GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<OrderViewModel> Search(OrderViewModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
