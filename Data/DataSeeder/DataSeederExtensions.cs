using Core.Entities;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataSeeder
{
    public static class DataSeederExtensions
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().HasData(
               new CategoryEntity { Id = 1, Name = "Home Services", Description = "Services related to home maintenance" },
               new CategoryEntity { Id = 2, Name = "Personal Services", Description = "Personal care and wellness services" }
            );

            modelBuilder.Entity<ServiceEntity>().HasData(
                new ServiceEntity { Id = 1, Name = "Cleaning", Description = "House cleaning service", Price = 100, Provider = "CleanCo", CategoryId = 1 },
                new ServiceEntity { Id = 2, Name = "Gardening", Description = "Garden maintenance service", Price = 150, Provider = "GreenThumb", CategoryId = 1 }
            );

            modelBuilder.Entity<BookingEntity>().HasData(
                new BookingEntity { Id = 1, UserId = "9ee7e8b2-e29a-486d-b4f5-70c52d2cd2d1",  BookingDate = DateTime.UtcNow, Status = "Confirmed", TotalAmount = 100, PaymentStatus = "Paid" },
                new BookingEntity { Id = 2, UserId = "9ee7e8b2-e29a-486d-b4f5-70c52d2cd2d1", BookingDate = DateTime.UtcNow, Status = "Pending", TotalAmount = 150, PaymentStatus = "Unpaid" }
            );
            
            modelBuilder.Entity<BookingDetailEntity>().HasData(
               new BookingDetailEntity { Id = 1, BookingId = 1, ServiceId = 1, ScheduledDate = DateTime.UtcNow.AddDays(1), Address = "123 Main St", Price = 100 },
               new BookingDetailEntity { Id = 2, BookingId = 2, ServiceId = 2, ScheduledDate = DateTime.UtcNow.AddDays(2), Address = "456 Oak St", Price = 150 }
            );
        }
    }
}
