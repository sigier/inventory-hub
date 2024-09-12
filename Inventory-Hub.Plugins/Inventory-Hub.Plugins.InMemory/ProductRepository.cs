using Inventory_Hub.CoreBusiness;
using Inventory_Hub.UseCases.PluginInterfaces;

namespace Inventory_Hub.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products;

        public ProductRepository()
        {
            inventories = new List<Product>
            {
                new Product
                {
                    ProductId = 3,
                    ProductName = "Car",
                    Quantity = 2,
                    Price = 250
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Plane",
                    Quantity = 3,
                    Price = 700
                }
            };
        }
        public async Task<IEnumerable<Product>> GetByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return await Task.FromResult(products);
            }

            return products.Where(o => o.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
