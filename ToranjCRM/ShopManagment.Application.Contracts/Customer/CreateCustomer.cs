using System.ComponentModel.DataAnnotations;
using ProjectFramework.Application;

namespace ShopManagement.Application.Contracts.Customer
{
    public class CreateCustomer
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PhoneNumber { get; set; }
        public string? NationalCode { get; set; }
        public string operatorName { get; set; }
    }
}
