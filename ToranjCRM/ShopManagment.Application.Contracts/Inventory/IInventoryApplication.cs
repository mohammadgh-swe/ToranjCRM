using ProjectFramework.Application;

namespace ShopManagement.Application.Contracts.Inventory
{
    public interface IInventoryApplication
    {                               
        OperationResult Create(CreateInventory command);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Decrease(DecreaseInventory command);
        OperationResult Decrease(List<DecreaseInventory> command);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);

    }
}