using ecom.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ecom.ViewModels
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }

        [Required]
        public  string ImageUrl { get; set; }
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
    }
}
