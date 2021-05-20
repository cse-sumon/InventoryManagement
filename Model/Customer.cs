using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public string Address { get; set; }
        public char CustomerType { get; set; }
    }
}
