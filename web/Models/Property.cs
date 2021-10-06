using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace web
{
    public class Property
    {
        public Guid Id { get; set; }
        public string Owner { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Address { get; set; }
        public decimal Rate { get; set; }
        [JsonIgnore]
        public List<Booking> Bookings { get; set; }

        public Property() { }
        public Property(PropertyDto propertyDto)
        {

            Id = Guid.NewGuid();
            Owner = propertyDto.Owner;
            City = propertyDto.City;
            State = propertyDto.State;
            Zipcode = propertyDto.Zipcode;
            Address = propertyDto.Address;
            Rate = propertyDto.Rate;
            Bookings = new();
        }
    }

}