using Inventory_Hub.CoreBusiness;

namespace Inventory_Hub.UseCases.PluginInterfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByNameAsync(string name);
    }
}
