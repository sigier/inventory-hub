using IMS.CoreBusiness;
using IMS.UseCases.Activity.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Activity
{
    public class ProduceProductUseCase : IProduceProductUseCase
    {
        private readonly IProductTransactionRepository productTransactionRepository;
        private readonly IProductRepository productRepository;

        public ProduceProductUseCase(IProductTransactionRepository productTransactionRepository, IProductRepository productRepository)
        {
            this.productTransactionRepository = productTransactionRepository; 
            this.productRepository = productRepository;
        }

        public async Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneBy)
        {
            await this.productTransactionRepository.ProduceAsync(productionNumber, product, quantity, doneBy);
            product.Quantity += quantity + 1;
            await this.productRepository.UpdateProductAsync(product);
        }
    }
}
