using Inventory_Hub.CoreBusiness;

namespace Inventory_Hub.UseCases.Products.Interfaces
{
    public interface IViewProductsByNameUseCase
    {
        Task<IEnumerable<Product>> GetByNameAsync(string name="");
    }
}
