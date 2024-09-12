using Inventory_Hub.CoreBusiness;
using Inventory_Hub.UseCases.PluginInterfaces;

namespace Inventory_Hub.Plugins.InMemory
{
    public class InventoryRepository: IInventoryRepository
    {
        private List<Inventory> inventories;

        public InventoryRepository()
        {
            inventories = new List<Inventory>
            {
                new Inventory
                {
                    InventoryId = 1,
                    InventoryName = "Bike Seat",
                    Quantity = 2,
                    Price = 25
                },
                new Inventory
                {
                    InventoryId = 2,
                    InventoryName = "Bike Belt",
                    Quantity = 3,
                    Price = 70
                }
            };
        }

        public async Task<IEnumerable<Inventory>> GetByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return await Task.FromResult(inventories);
            }

            return inventories.Where(o => o.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public  Task AddInventoryAsync(Inventory inventory)
        {
            if (inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            int maxId = inventories.Max(x => x.InventoryId);
            inventory.InventoryId = maxId+1;

            inventories.Add(inventory);
            return Task.CompletedTask;
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            if (inventories.Any(x => x.InventoryId != inventory.InventoryId && x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            Inventory? updateInventory = inventories.FirstOrDefault(c => c.InventoryId == inventory.InventoryId);
            if (updateInventory is not null)
            {
                updateInventory.InventoryName = inventory.InventoryName;
                updateInventory.Price = inventory.Price;
                updateInventory.Quantity = inventory.Quantity;
            }

            await Task.CompletedTask;
        }

        public async Task<Inventory?> GetByIdAsync(int inventoryId)
        {
            return await Task.FromResult(inventories.FirstOrDefault(x => x.InventoryId == inventoryId));
        }

        public async Task DeleteInventoryByIdAsync(int inventoryId)
        {
            Inventory? inventory = inventories.FirstOrDefault(x => x.InventoryId == inventoryId);
            if (inventory is not null)
            {
                inventories.Remove(inventory);
            }

            await Task.CompletedTask;
        }
    }
}
