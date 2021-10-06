using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace web
{   
  public record Weather(string name, int id);
  
  public class PropertyRepository: IPropertyRepository
  {
    

    private Database _db;


    public async Task<IEnumerable<Property>> GetAllAsync()
    {
        return await _db.Properties.ToListAsync();
    }

    public async Task<Property> SearchByIdAsync(Guid id)
    {
        return await _db.Properties
        .Where(t => t.Id == id)
        .SingleOrDefaultAsync();
    }

    public async Task AddAsync(Property property)
    {
        await _db.AddAsync(property);
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

     public async Task BookingAsync(Booking booking)
    {   var property = _db.Properties.Where(p => p.Id == booking.Property.Id).First();
        await _db.AddAsync(booking);
        property.Bookings.Add(booking);
    }


    public async Task<IEnumerable<Property>> SearchPropertiesByOwnerAsync(string owner)
    {
        return await _db.Properties
        .Where(t => t.Owner.ToLower().Contains(owner.ToLower())).ToListAsync();
    }

    public async Task<IEnumerable<Property>> SearchByFields(string keyword)
    {
        return await _db.Properties
        .Where(t => t.City.ToLower().Contains(keyword.ToLower()) || t.State.ToLower().Contains(keyword.ToLower()) || t.Zipcode == Int32.Parse(keyword)).ToListAsync();
    }

     public async Task<Weather> GetWeather(string cityname)
    {   
        var client = new HttpClient(); 
        var weather = await client.GetFromJsonAsync<Weather>($"https://api.openweathermap.org/data/2.5/weather?q={cityname}&appid=7a5c4cae858e5269cc79ac58520d57a4&units=imperial");
    
        // string jsonString = JsonSerializer.Deserialize(client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityname}&appid=7a5c4cae858e5269cc79ac58520d57a4&units=imperial").Result.Content);
        return weather;
    }
    public async Task<IEnumerable<Booking>> SearchBookingsById(Guid id)
    {
        return await _db.Bookings
        .Where(p => p.Id == id).ToListAsync();
    }
    public PropertyRepository(Database db)
    {
        _db = db;
    }
  }
}
