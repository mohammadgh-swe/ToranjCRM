using ProjectFramework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Size { get; private set; }
        public string Picture { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; private set; }
        public int ProductCount { get; set; }
        public string Slug { get; private set; }

        //public int CompanyId { get; private set; }
        //public Company Company { get; set; }

        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }
    }
}
