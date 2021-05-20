using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double PurchasePrice { get; set; }
        [Required]
        public double SalePrice { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
