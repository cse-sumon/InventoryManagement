using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
    public class RevenueViewModel
    {
        public int RevenueId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public string Amount { get; set; }
        public string Description { get; set; }
        public string InvoiceId { get; set; }
    }
}
