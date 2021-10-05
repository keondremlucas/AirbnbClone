using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace web
{
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

    // void Book(Property property);
    // Task<IEnumerable<Property>> SearchPropertiesByOwnerAsync(string owner);
    // void CreateProperty(Property property);


    public async Task BookAsync(Guid guid)
    {   await _db.where
        await _db.AddAsync(booking);
        property.Bookings.Add(booking);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Property>> SearchPropertiesByOwnerAsync(string owner)
    {
        return await _db.Properties
        .Where(t => t.Owner == owner).ToListAsync();
    }


    public PropertyRepository(Database db)
    {
        _db = db;
    }
  }
}
