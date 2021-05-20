using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        
        public IFormFile FormFile { get; set; }
        public string Picture { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
