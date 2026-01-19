using Microsoft.EntityFrameworkCore;
using EventsApp.Domain.Entities;


namespace EventsApp.DataAccess
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
