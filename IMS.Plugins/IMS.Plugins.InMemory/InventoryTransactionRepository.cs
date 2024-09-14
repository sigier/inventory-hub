using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        public List<InventoryTransaction> inventoryTransactions = new List<InventoryTransaction>();

        public void  PurchaseAsync(string purchaseOrderNumber, Inventory inventory, int quantity, string doneBy, double price)
        {
            this.inventoryTransactions.Add(new InventoryTransaction
            {
                PurchaseOrderNumber = purchaseOrderNumber,
                InventoryId = inventory.InventoryId,
                QuantityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionType.PurchaseInventory,
                QuantityAfter = inventory.Quantity+quantity,
                UnitPrice = price,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
            });
        }
    }
}
