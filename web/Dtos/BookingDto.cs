using System;
using System.ComponentModel.DataAnnotations;

namespace web
{
    public class BookingDto
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public Guid PropertyGuid { get; set; }
    }
}
