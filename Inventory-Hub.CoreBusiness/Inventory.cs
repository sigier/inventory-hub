using System.ComponentModel.DataAnnotations;

namespace Inventory_Hub.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        [Required]
        [StringLength(150)]
        public string InventoryName { get; set; } = string.Empty;

        [Range(0, Int32.MaxValue, ErrorMessage = "Please, enter correct value, greater or equal to zero.")]
        public int Quantity { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "Please, enter correct value, greater or equal to zero.")]

        public double Price { get; set; }
    }
}
