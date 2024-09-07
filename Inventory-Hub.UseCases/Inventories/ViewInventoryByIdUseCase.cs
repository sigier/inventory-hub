using Inventory_Hub.CoreBusiness;
using Inventory_Hub.UseCases.Inventories.Interfaces;
using Inventory_Hub.UseCases.PluginInterfaces;

namespace Inventory_Hub.UseCases.Inventories
{
    public class ViewInventoryByIdUseCase : IViewInventoryByIdUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoryByIdUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public async Task<Inventory?> ExecuteAsync(int inventoryId)
        {
           return await this.inventoryRepository.GetByIdAsync(inventoryId);
        }
    }
}
