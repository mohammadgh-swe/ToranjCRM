using Microsoft.EntityFrameworkCore;
using ProjectFramework.Infrastructure;
using ShopManagement.Application.Contracts.Customer;
using ShopManagement.Domain.CustomerAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class CustomerRepository : RepositoryBase<long, Customer>, ICustomerRepository
    {
        private readonly ShopContext _context;

        public CustomerRepository(ShopContext context) : base(context)
        {
            _context = context;
        }


        public EditCustomer GetDetails(long id)
        {
            return _context.Customers.Select(x => new EditCustomer
            {
                Id = x.Id,
                
                PhoneNumber = x.PhoneNumber,
                NationalCode = x.NationalCode,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerViewModel> Search(CustomerSearchModel searchModel)
        {
            var query = _context.Customers.Select(x => new CustomerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                NationalCode = x.NationalCode
            });

            //if (!string.IsNullOrWhiteSpace(searchModel.Name))
            //    query = query.Where(x => x.Firstname.Contains(searchModel.Name) 
            //                             || x.Lastname.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
