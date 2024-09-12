using Inventory_Hub.CoreBusiness;
using Inventory_Hub.UseCases.Products.Interfaces;

namespace Inventory_Hub.UseCases.Products
{
    public class ViewProductsByNameUseCase : IViewProductsByNameUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewProductsByNameUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetByNameAsync(string name = "")
        {
            return await productRepository.GetByNameAsync(name);
        }
    }
}
