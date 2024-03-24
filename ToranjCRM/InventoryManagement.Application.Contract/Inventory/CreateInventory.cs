using System.ComponentModel.DataAnnotations;
using ProjectFramework.Application;
using ShopManagement.Application.Contracts.Product;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class CreateInventory
    {
        [Range(1, long.MaxValue,ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public double UnitPrice { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
  