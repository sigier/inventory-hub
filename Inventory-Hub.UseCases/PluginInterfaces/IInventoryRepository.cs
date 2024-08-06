using Inventory_Hub.CoreBusiness;

namespace Inventory_Hub.UseCases.PluginInterfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetByNameAsync(string name);
    }
}
