using Inventory_Hub.CoreBusiness;
using Inventory_Hub.UseCases.PluginInterfaces;
using Inventory_Hub.UseCases.Inventories.Interfaces;

namespace Inventory_Hub.UseCases.Inventories
{
    public class EditInventoryUseCase : IEditInventoryUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public EditInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(Inventory inventory)
        {
            await this.inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
