﻿using Inventory_Hub.CoreBusiness;
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
    }
}
