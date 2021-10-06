using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web
{
  public interface IPropertyRepository
  {
  
    Task<IEnumerable<Property>> GetAllAsync();
    Task<Property> SearchByIdAsync(Guid id);
    Task AddAsync(Property property);
    Task SaveAsync();

    Task<IEnumerable<Property>> SearchPropertiesByOwnerAsync(string owner);
    Task<IEnumerable<Booking>> SearchBookingsById(Guid id);

    Task<IEnumerable<Property>> SearchByFields(string keyword);
    Task<Weather> GetWeather(string cityname);

    Task BookingAsync(Booking booking);
    //string CheckWeather(Property property);
  }
}
