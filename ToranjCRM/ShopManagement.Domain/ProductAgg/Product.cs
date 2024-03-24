using ProjectFramework.Domain;
using ShopManagement.Domain.CompanyAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using System.ComponentModel.Design;
using ShopManagement.Domain.ProductPictureAgg;

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
        public string Slug { get; private set; }

        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }

        public long CompanyId { get; private set; }
        public Company Company { get; set; }

        public List<ProductPicture> ProductPictures { get; private set; }

        public Product(string name, string code, string shortDescription,
            string description, string size, string picture,
            string slug, long categoryId, long companyId)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Size = size;
            Picture = picture;
            Slug = slug;
            CategoryId = categoryId;
            CompanyId = companyId;
        }

        public void Edit(string name, string code, string shortDescription,
            string description, string size, string picture,
            string slug, long categoryId, long companyId)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Size = size;
            Picture = picture;
            Slug = slug;
            CategoryId = categoryId;
            CompanyId = companyId;

            UpdateAt = DateTime.Now;
            UpdatedBy = " ";
        }

    }


}
