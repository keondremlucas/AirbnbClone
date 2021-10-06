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
    Task BookAsync(BookingDto booking);
    //string CheckWeather(Property property);
  }
}
