using IMS.CoreBusiness;
using IMS.UseCases.Activity.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Activity
{
    public class PurchaseInventoryUseCase : IPurchaseInventoryUseCase
    {

        private readonly IInventoryTransactionRepository inventoryTransactionRepository;
        private readonly IInventoryRepository inventoryRepository;

        public PurchaseInventoryUseCase(IInventoryTransactionRepository inventoryTransactionRepository, IInventoryRepository inventoryRepository)
        {
            this.inventoryTransactionRepository = inventoryTransactionRepository;
            this.inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(string purchaseOrderNumber, Inventory inventory, int quantity, string doneBy)
        {
            inventoryTransactionRepository.PurchaseAsync(purchaseOrderNumber, inventory, quantity, doneBy, inventory.Price);
            inventory.Quantity += quantity;
            await this.inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }

}
