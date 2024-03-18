using ProjectFramework.Application;
using ProjectFramework.Domain;
using ShopManagement.Domain.ProductAgg;
using System.ComponentModel.DataAnnotations;

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
        public string Slug { get; private set; }

        public List<Product> Products { get; private set; }

        public Company()
        {
            Products = new List<Product>();
        }
        public Company(string name, string address, string agentName, string agentPhoneNubmber, string phoneNumber, string description, string slug)
        {
            Name = name;
            Address = address;
            AgentName = agentName;
            AgentPhoneNubmber = agentPhoneNubmber;
            PhoneNumber = phoneNumber;
            Description = description;
            Slug = slug;
        }

        public void Edit(string name, string address, string agentName, string agentPhoneNubmber, string phoneNumber, string description, string slug)
        {
            Name = name;
            Address = address;
            AgentName = agentName;
            AgentPhoneNubmber = agentPhoneNubmber;
            PhoneNumber = phoneNumber;
            Description = description;
            Slug = slug;

            UpdateAt = DateTime.Now;
            UpdatedBy = " ";
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
