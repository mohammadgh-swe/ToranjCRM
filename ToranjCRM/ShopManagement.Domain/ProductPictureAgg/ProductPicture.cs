using ProjectFramework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public class ProductPicture : BaseEntity
    {

        public string Picture { get; private set; }
        public string PictureTitle { get; private set; }

        public long ProductId { get; private set; }
        public Product Product { get; private set; }


        public ProductPicture(string picture, string pictureTitle, long productId)
        {
            Picture = picture;
            PictureTitle = pictureTitle;
            ProductId = productId;
        }

        public void Edit(string picture, string pictureTitle, long productId)
        {
            Picture = picture;
            PictureTitle = pictureTitle;
            ProductId = productId;

            UpdatedBy = " ";
            UpdateAt = DateTime.Now;
        }
    }

}
