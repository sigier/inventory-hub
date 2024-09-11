using Inventory_Hub.UseCases.Inventories.Interfaces;
using Inventory_Hub.UseCases.PluginInterfaces;

namespace Inventory_Hub.UseCases.Inventories
{
    public class DeleteInventoryUseCase : IDeleteInventoryUseCase
    {

        private readonly IInventoryRepository inventoryRepository;

        public DeleteInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(int inventoryId)
        {
           await this.inventoryRepository.DeleteInventoryByIdAsync(inventoryId);
        }
    }
}
