using ProjectFramework.Application;
using ShopManagement.Application.Contracts.Customer;
using ShopManagement.Domain.CustomerAgg;

namespace ShopManagement.Application
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerApplication(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public OperationResult Create(CreateCustomer command)
        {
            var operaton = new OperationResult();
            if (_customerRepository.Exists(x => x.Firstname == command.Firstname 
                                                || x.Lastname == command.Lastname 
                                                || x.PhoneNumber == command.PhoneNumber))
                return operaton.Failed(ApplicationMessage.DuplicatedRecord);

            var customer = new Customer(command.Firstname, command.Lastname, command.PhoneNumber,
                command.NationalCode, command.CompanyId);
            _customerRepository.Create(customer);
            _customerRepository.SaveChanges();
            return operaton.Succeed();
        }

        public OperationResult Edit(EditCustomer command)
        {
            var operation = new OperationResult();
            var customer = _customerRepository.Get(command.Id);
            if (customer == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_customerRepository.Exists(x => x.Firstname == command.Firstname
                                                || x.Lastname == command.Lastname
                                                || x.PhoneNumber == command.PhoneNumber
                                                && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            customer.Edit(command.Firstname, command.Lastname, command.PhoneNumber,
                command.NationalCode, command.CompanyId);
            _customerRepository.SaveChanges();
            return operation.Succeed();
        }

        public EditCustomer GetDetails(long id)
        {
            return _customerRepository.GetDetails(id);
        }

        public List<CustomerViewModel> Search(CustomerSearchModel searchModel)
        {
            return _customerRepository.Search(searchModel);
        }
    }
}
