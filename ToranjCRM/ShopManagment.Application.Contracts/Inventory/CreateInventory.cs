using System.ComponentModel.DataAnnotations;
using ProjectFramework.Application;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Application.Contracts.Inventory
{
    public class CreateInventory
    {
        [Range(1, long.MaxValue,ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
  