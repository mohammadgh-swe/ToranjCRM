using ProjectFramework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.CompanyAgg
{
    public class Company : BaseEntity
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string AgentName { get; private set; }
        public string AgentPhoneNubmber { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Description { get; private set; }

        public List<Product> Products { get; private set; }
    }
}
