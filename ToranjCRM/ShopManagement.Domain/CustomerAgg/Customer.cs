using ProjectFramework.Domain;
using ShopManagement.Domain.CompanyAgg;

namespace ShopManagement.Domain.CustomerAgg
{
    public class Customer : BaseEntity
    {
        public string Firstname{ get; private set; }
        public string Lastname { get; private set; }
        public string PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }

        public long CompanyId { get; private set; }
        public Company Company { get; private set; }

        public Customer(string firstname, string lastname, string phoneNumber, string nationalCode, long companyId)
        {
            Firstname = firstname;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            CompanyId = companyId;
        }

        public void Edit(string firstname, string lastname, string phoneNumber, string nationalCode, long companyId)
        {
            Firstname = firstname;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            CompanyId = companyId;

            UpdatedBy = " ";
            UpdateAt = DateTime.Now;
        }
    }
}
