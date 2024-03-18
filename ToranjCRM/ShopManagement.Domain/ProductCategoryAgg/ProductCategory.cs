using ProjectFramework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string Slug { get; private set; }
        public List<Product> Products { get; private set; }

        public ProductCategory()
        {
            Products = new List<Product>();
        }

        public ProductCategory(string name, string description, string picture, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            Slug = slug;
        }

        public void Edit(string name, string description, string picture, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
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
