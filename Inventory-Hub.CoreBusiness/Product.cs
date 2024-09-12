using System.ComponentModel.DataAnnotations;

namespace Inventory_Hub.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(150)]
        public string ProductName { get; set; } = string.Empty;

        [Range(0, Int32.MaxValue, ErrorMessage = "Please, enter correct value, greater or equal to zero.")]
        public int Quantity { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "Please, enter correct value, greater or equal to zero.")]

        public double Price { get; set; }
    }
}
