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
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Связь Event -> Image (один ко многим)
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Image)
                .WithMany() // ВАЖНО: WithMany() без параметров
                .HasForeignKey(e => e.ImageId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
