using System;
using System.ComponentModel.DataAnnotations;

namespace web
{
    public class PropertyDto
    {
        [Required]
        public string Owner { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [MaxLength(2)]
        public string State { get; set; }
        [Required]
        [MaxLength(5)]
        public string Zipcode { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public decimal Rate { get; set; }
    }
}
