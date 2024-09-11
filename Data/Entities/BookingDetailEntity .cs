using Core.Interfaces;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BookingDetailEntity : BaseEntity
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int ServiceId { get; set; }
        public DateTime ScheduledDate { get; set; } 
        public string Address { get; set; } 

        public BookingEntity Booking { get; set; }
        public ServiceEntity Service { get; set; }

        public decimal Price { get; set; } 
    }
}
