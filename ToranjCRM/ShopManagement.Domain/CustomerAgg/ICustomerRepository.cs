using ProjectFramework.Domain;
using ShopManagement.Application.Contracts.Customer;

namespace ShopManagement.Domain.CustomerAgg
{
    public interface ICustomerRepository : IRepository<long, Customer>
    {
        EditCustomer GetDetails(long id);
        List<CustomerViewModel> Search(CustomerSearchModel searchModel);
    }
}
