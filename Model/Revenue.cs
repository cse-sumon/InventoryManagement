using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class Revenue
    {
        public int RevenueId { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public string Amount { get; set; }
        public string Description { get; set; }
        public string InvoiceId { get; set; }
    }
}
