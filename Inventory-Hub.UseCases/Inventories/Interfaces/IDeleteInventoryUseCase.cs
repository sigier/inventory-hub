using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Hub.UseCases.PluginInterfaces;

namespace Inventory_Hub.UseCases.Inventories.Interfaces
{
    public interface IDeleteInventoryUseCase
    {
        Task ExecuteAsync(int inventoryId);
    }
}
