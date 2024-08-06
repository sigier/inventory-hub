using Inventory_Hub.CoreBusiness;
using Inventory_Hub.UseCases.PluginInterfaces;


namespace Inventory_Hub.UseCases.Inventories
{
    public class ViewInventoriesByNameUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoriesByNameUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
           return await inventoryRepository.GetByNameAsync(name);
        }
    }
}
