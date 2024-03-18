using ProjectFramework.Domain;
using ShopManagement.Domain.CompanyAgg;
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

        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }

        public long CompanyId { get; private set; }
        public Company Company { get; set; }

        public Product(string name, string code, string shortDescription,
            string description, string size, string picture, double unitPrice,
            int productCount, string slug, long categoryId)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Size = size;
            Picture = picture;
            UnitPrice = unitPrice;
            ProductCount = productCount;
            Slug = slug;
            CategoryId = categoryId;
            IsInStock = true;
        }

        public void Edit(string name, string code, string shortDescription,
            string description, string size, string picture, double unitPrice,
            int productCount, string slug, long categoryId)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Size = size;
            Picture = picture;
            UnitPrice = unitPrice;
            ProductCount = productCount;
            Slug = slug;
            CategoryId = categoryId;

            UpdateAt = DateTime.Now;
            UpdatedBy = " ";
        }

        public void InStock()
        {
            IsInStock = true;
        }

        public void NotInStock()
        {
            IsInStock = false;
        }
    }


}
