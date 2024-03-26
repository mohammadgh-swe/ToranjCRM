using System.ComponentModel.DataAnnotations;
using ProjectFramework.Application;

namespace ShopManagement.Application.Contracts.OrderDetail
{
    public class CreateOrderDetail
    {
        public long ProductId { get; set; }
        public long OrderId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public int Count { get; set; }
    }
}
