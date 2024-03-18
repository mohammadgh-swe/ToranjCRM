using System.ComponentModel.DataAnnotations;
using ProjectFramework.Application;
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public string? Picture { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public double UnitPrice { get; set; }
        [Range(0, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public int ProductCount { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Slug { get; set; }
        [Range(1,100000, ErrorMessage = ValidationMessage.IsRequired)]
        public long CategoryId { get; set; }
        public List<ProductCategoryViewModel> Categories { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long CompanyId { get; set; }
        public List<CompanyViewModel> Companies{ get; set; }
    }
}
