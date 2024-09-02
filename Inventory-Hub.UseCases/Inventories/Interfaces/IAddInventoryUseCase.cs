
using Inventory_Hub.CoreBusiness;

namespace Inventory_Hub.UseCases.Inventories.Interfaces
{
    public interface IAddInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}
