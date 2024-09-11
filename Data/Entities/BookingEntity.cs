using Core.Entities;
using Core.Interfaces;

namespace Data.Entities
{
    public class BookingEntity : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }

        public UserEntity User { get; set; }
        public string Status { get; set; } 
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; } = "Unpaid"; // "Paid", "Unpaid", "Refunded"

        public ICollection<BookingDetailEntity> BookingDetails { get; set; }
    }
}
