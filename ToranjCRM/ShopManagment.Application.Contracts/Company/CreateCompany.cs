using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using ProjectFramework.Application;

namespace ShopManagement.Application.Contracts.Company
{
    public class CreateCompany
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? AgentName { get; set; }
        public string? AgentPhoneNubmber { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PhoneNumber { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Slug { get; set; }
    }
}
