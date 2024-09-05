using Core.Entities;
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
        public DbSet<BookingDetailEntity> BookingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Додаємо початкові дані
            modelBuilder.Entity<ServiceEntity>().HasData(
                new ServiceEntity { Id = 1, Name = "Cleaning", Description = "House cleaning service", Price = 100, Provider = "CleanCo", CategoryId = 1 },
                new ServiceEntity { Id = 2, Name = "Gardening", Description = "Garden maintenance service", Price = 150, Provider = "GreenThumb", CategoryId = 1 }
            );

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PasswordHash = "hashed_password_1", Role = "User", PhoneNumber = "123456789" },
                new UserEntity { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PasswordHash = "hashed_password_2", Role = "Admin", PhoneNumber = "987654321" }
            );

            modelBuilder.Entity<BookingEntity>().HasData(
                new BookingEntity { Id = 1, UserId = 1, BookingDate = DateTime.UtcNow, Status = "Confirmed", TotalAmount = 100, PaymentStatus = "Paid" },
                new BookingEntity { Id = 2, UserId = 2, BookingDate = DateTime.UtcNow, Status = "Pending", TotalAmount = 150, PaymentStatus = "Unpaid" }
            );

            modelBuilder.Entity<CategoryEntity>().HasData(
               new CategoryEntity { Id = 1, Name = "Home Services", Description = "Services related to home maintenance" },
               new CategoryEntity { Id = 2, Name = "Personal Services", Description = "Personal care and wellness services" }
           );
            modelBuilder.Entity<BookingDetailEntity>().HasData(
               new BookingDetailEntity { Id = 1, BookingId = 1, ServiceId = 1, ScheduledDate = DateTime.UtcNow.AddDays(1), Address = "123 Main St", Price = 100 },
               new BookingDetailEntity { Id = 2, BookingId = 2, ServiceId = 2, ScheduledDate = DateTime.UtcNow.AddDays(2), Address = "456 Oak St", Price = 150 }
           );
        }
    }
}
