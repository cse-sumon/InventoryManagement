using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double PurchasePrice { get; set; }
        [Required]
        public double SalePrice { get; set; }
        public string Picture { get; set; }
        public IFormFile IFormFile { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
