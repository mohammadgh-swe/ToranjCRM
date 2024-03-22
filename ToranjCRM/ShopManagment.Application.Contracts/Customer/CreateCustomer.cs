using System.ComponentModel.DataAnnotations;
using ProjectFramework.Application;

namespace ShopManagement.Application.Contracts.Customer
{
    public class CreateCustomer
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Lastname { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PhoneNumber { get; set; }
        public string? NationalCode { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long CompanyId { get; set; }
    }
}
