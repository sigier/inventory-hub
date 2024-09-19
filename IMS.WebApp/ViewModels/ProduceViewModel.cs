﻿using IMS.CoreBusiness;
using System.ComponentModel.DataAnnotations;
using IMS.WebApp.ViewModelValidations;

namespace IMS.WebApp.ViewModels
{
    public class ProduceViewModel
    {
        [Required]
        public string ProductionNumber { get; set; } = string.Empty;

        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "You have to select a product.")]
        public int ProductId { get; set; }

        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity has to be greater or equal to 1.")]
        [Produce_EnsureEnoughInventoryQuantity]
        public int QuantityToProduce { get; set; }

        public Product? Product { get; set; }
    }
}
