using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ViewModel
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [Required]
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public string Amount { get; set; }
        public string Description { get; set; }
        public string BillId { get; set; }
    }
}
