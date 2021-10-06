using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web
{
    public interface IPropertyRepository
    {

        Task<IEnumerable<Property>> GetAllAsync(); //tested
        Task<Property> SearchByIdAsync(Guid id); //tested
        Task AddAsync(Property property); //tested
        Task SaveAsync(); //tested
        Task<IEnumerable<Property>> SearchPropertiesByOwnerAsync(string owner); //tested
        Task BookingAsync(Booking booking);
        Task<IEnumerable<Booking>> SearchBookingsById(Guid id);
        Task<IEnumerable<Property>> SearchByFields(string keyword);
        Task<Weather> GetWeather(string cityname);
    }
}
