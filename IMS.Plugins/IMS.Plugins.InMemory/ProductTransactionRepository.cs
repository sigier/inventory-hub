﻿using IMS.UseCases.PluginInterfaces;
using IMS.CoreBusiness;

namespace IMS.Plugins.InMemory
{
    public class ProductTransactionRepository : IProductTransactionRepository
    {
        private List<ProductTransaction> _productTransactions = new List<ProductTransaction>();

        private readonly IProductRepository productRepository;
        private readonly IInventoryTransactionRepository inventoryTransactionRepository;
        private readonly IInventoryRepository inventoryRepository;

        public ProductTransactionRepository(IProductRepository productRepository, IInventoryTransactionRepository inventoryTransactionRepository, IInventoryRepository inventoryRepository)
        {
            this.productRepository = productRepository;
            this.inventoryTransactionRepository = inventoryTransactionRepository;
            this.inventoryRepository = inventoryRepository;
        }

        public async Task ProduceAsync(string productionNumber, Product product, int quantity, string doneBy)
        {
            //decrease the inventories
            var prod = await this.productRepository.GetProductByIdAsync(product.ProductId);
            if (prod is not null && prod.ProductInventories is not null && prod.ProductInventories.Count > 0)
            {
                foreach (var pi in prod.ProductInventories)
                {
                    if (pi.Inventory is not null)
                    {
                        //add inventory transaction
                        await this.inventoryTransactionRepository.ProduceAsync(productionNumber,
                            pi.Inventory,
                            pi.InventoryQuantity * quantity,
                            doneBy,
                            -1);

                        //decrease the inventories
                        var inv = await this.inventoryRepository.GetInventoryByIdAsync(pi.InventoryId);
                        inv.Quantity -= pi.InventoryQuantity * quantity;
                        await this.inventoryRepository.UpdateInventoryAsync(inv);
                    }
                }
            }

            //add product transaction
            this._productTransactions.Add(new ProductTransaction
            {
                ProductionNumber = productionNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                ActivityType = ProductTransactionType.ProductProduct,
                QuantityAfter = product.Quantity + quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy
            });
        }
    }
}