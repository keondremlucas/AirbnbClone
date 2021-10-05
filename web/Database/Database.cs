using Microsoft.EntityFrameworkCore;

namespace web
{
    public class Database : DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public Database(DbContextOptions<Database> options) : base(options) { }
    }
}