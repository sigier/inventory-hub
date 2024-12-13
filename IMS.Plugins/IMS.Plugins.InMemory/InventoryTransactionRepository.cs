using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        public List<InventoryTransaction> _inventoryTransactions = new List<InventoryTransaction>();
        private readonly IInventoryRepository inventoryRepository;

        public InventoryTransactionRepository(IInventoryRepository inventoryRepository)
        {
                this.inventoryRepository = inventoryRepository;
        }

        public Task ProduceAsync(string productionNumber, Inventory inventory, int quantityToConsume, string doneBy, double price)
        {
            this._inventoryTransactions.Add(new InventoryTransaction
            {
                PurchaseOrderNumber = productionNumber,
                InventoryId = inventory.InventoryId,
                QuantityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionType.ProduceProduct,
                QuantityAfter = inventory.Quantity - quantityToConsume,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<CoreBusiness.InventoryTransaction>> GetInventoryTransactionAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo,
            InventoryTransactionType? transactionType)
        {
            var inventories = (await inventoryRepository.GetInventoriesByNameAsync(string.Empty)).ToList();

            IEnumerable<InventoryTransaction> query = from it in this._inventoryTransactions
                join inv in inventories on it.InventoryId equals inv.InventoryId
                where
                    (string.IsNullOrWhiteSpace(inventoryName) || inv.InventoryName.ToLower().IndexOf(inventoryName.ToLower()) >= 0)
                    &&
                    (!dateFrom.HasValue || it.TransactionDate >= dateFrom.Value.Date) &&
                    (!dateTo.HasValue || it.TransactionDate <= dateTo.Value.Date) &&
                    (!transactionType.HasValue || it.ActivityType == transactionType)
                select new InventoryTransaction
                {
                    Inventory = inv,
                    InventoryTransactionId = it.InventoryTransactionId,
                    PurchaseOrderNumber = it.PurchaseOrderNumber,
                    InventoryId = it.InventoryId,
                    QuantityBefore = it.QuantityBefore,
                    ActivityType = it.ActivityType,
                    QuantityAfter = it.QuantityAfter,
                    TransactionDate = it.TransactionDate,
                    DoneBy = it.DoneBy,
                    UnitPrice = it.UnitPrice
                };

            return query;
        }

        public Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneBy, double price)
        {
            this._inventoryTransactions.Add(new InventoryTransaction
            {
                PurchaseOrderNumber = poNumber,
                InventoryId = inventory.InventoryId,
                QuantityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionType.PurchaseInventory,
                QuantityAfter = inventory.Quantity + quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });

            return Task.CompletedTask;
        }
    }
}
