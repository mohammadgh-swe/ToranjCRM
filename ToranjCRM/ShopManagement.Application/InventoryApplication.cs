using ProjectFramework.Application;
using ShopManagement.Application.Contracts.Inventory;
using ShopManagement.Domain.InventoryAgg;

namespace ShopManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public OperationResult Create(CreateInventory command)
        {
            var operation = new OperationResult();

            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var inventory = new Inventory(command.ProductId, command.CreationDate);

            _inventoryRepository.Create(inventory);
            _inventoryRepository.SaveChanges();
            return operation.Succeed();
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            const long operatotId = 1;
            inventory.Increase(command.Count, operatotId, command.Description);
            _inventoryRepository.SaveChanges();
            return operation.Succeed();
        }

        public OperationResult Decrease(DecreaseInventory command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            const long operatorId = 1;
            inventory.Decrease(command.Count, operatorId, command.Description, 0);
            _inventoryRepository.SaveChanges();
            return operation.Succeed();
        }

        public OperationResult Decrease(List<DecreaseInventory> command)
        {
            var operation = new OperationResult();
            const long operatorId = 1;
            foreach (var decreaseInventory in command)
            {
                var inventory = _inventoryRepository.GetBy(decreaseInventory.ProductId);
                inventory.Decrease(decreaseInventory.Count, operatorId, decreaseInventory.Description, decreaseInventory.OrderId );
            }
            _inventoryRepository.SaveChanges();
            return operation.Succeed();

        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _inventoryRepository.Search(searchModel);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            return _inventoryRepository.GetOperationLog(inventoryId);
        }
    }
}
