using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ServiceEntity> Services { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Додаємо початкові дані
            modelBuilder.Entity<ServiceEntity>().HasData(
                new ServiceEntity { Id = 1, Name = "Cleaning", Description = "House cleaning service", Price = 100, Provider = "CleanCo", CategoryId = 1 },
                new ServiceEntity { Id = 2, Name = "Gardening", Description = "Garden maintenance service", Price = 150, Provider = "GreenThumb", CategoryId = 1 }
            );

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new UserEntity { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" }
            );

            modelBuilder.Entity<BookingEntity>().HasData(
                new BookingEntity { Id = 1, ServiceId = 1, UserId = 1, BookingDate = DateTime.UtcNow.AddDays(-1) },
                new BookingEntity { Id = 2, ServiceId = 2, UserId = 2, BookingDate = DateTime.UtcNow }
            );

            modelBuilder.Entity<CategoryEntity>().HasData(
               new CategoryEntity { Id = 1, Name = "Home Services", Description = "Services related to home maintenance" },
               new CategoryEntity { Id = 2, Name = "Personal Services", Description = "Personal care and wellness services" }
           );
        }
    }
}
