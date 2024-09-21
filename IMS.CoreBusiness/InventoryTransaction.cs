using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class InventoryTransaction
    {
        public string PurchaseOrderNumber { get; set; } = string.Empty;
        public string ProductionOrderNumber { get; set; } = string.Empty;

        public int InventoryTransactionId { get; set; }

        [Required]
        public int InventoryId { get; set; }

        public int QuantityBefore { get; set; }

        [Required]
        public InventoryTransactionType ActivityType { get; set; }

        [Required]
        public int QuantityAfter { get; set; }

        public double UnitPrice { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public string DoneBy { get; set; } = string.Empty;

        public Inventory? Inventory  { get; set; }
    }
}
