using ProjectFramework.Application;

namespace ShopManagement.Application.Contracts.Customer
{
    public interface ICustomerApplication
    {
        OperationResult Create(CreateCustomer command);
        OperationResult Edit(EditCustomer command);
        EditCustomer GetDetails(long id);
        List<CustomerViewModel> Search(CustomerSearchModel searchModel);
    }
}
