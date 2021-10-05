using System;
using System.Text.Json.Serialization;

namespace web
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [JsonIgnore]
        public Property Property { get; set; }
        [JsonIgnore]
        public decimal Cost { get; set; }

        public Booking() { }

        public Booking(BookingDto bookingDto)
        {
            Id = Guid.NewGuid();
            this.StartDate = bookingDto.StartDate;
            this.EndDate = bookingDto.EndDate;
            Cost = Property.Rate * (EndDate - StartDate).Days;
        }
    }
}