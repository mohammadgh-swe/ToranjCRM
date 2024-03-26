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


        public List<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }

        public Customer(string name, string phoneNumber, string nationalCode = null)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
        }

        public void Edit(string name, string phoneNumber, string nationalCode, string operatorName = " ")
        {
            Name = name;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            UpdatedBy = operatorName;
            UpdateAt = DateTime.Now;
        }
    }
}
