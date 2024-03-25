using ProjectFramework.Domain;
using ShopManagement.Domain.CompanyAgg;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Domain.CustomerAgg
{
    public class Customer : BaseEntity
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }

        public long CompanyId { get; private set; }
        public Company Company { get; private set; }

        public List<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }

        public Customer(string name, string phoneNumber, long companyId, string nationalCode = null)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            CompanyId = companyId;
        }

        public void Edit(string name, string phoneNumber, string nationalCode, long companyId, string operatorName = " ")
        {
            Name = name;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            CompanyId = companyId;
            UpdatedBy = operatorName;
            UpdateAt = DateTime.Now;
        }
    }
}
