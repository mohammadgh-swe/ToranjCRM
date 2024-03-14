using System.ComponentModel.DataAnnotations;
using ProjectFramework.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Picture { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Keywords { get; set; }    //

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Slug { get; set; }    //
    }
}
