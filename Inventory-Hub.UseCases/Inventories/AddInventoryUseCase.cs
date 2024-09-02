using Inventory_Hub.CoreBusiness;
using Inventory_Hub.UseCases.Inventories.Interfaces;
using Inventory_Hub.UseCases.PluginInterfaces;

namespace Inventory_Hub.UseCases.Inventories
{
    public class AddInventoryUseCase : IAddInventoryUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public AddInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(Inventory inventory)
        {
           await this.inventoryRepository.AddInventoryAsync(inventory);
        }
    }
}
