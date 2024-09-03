using Core.Interfaces;

namespace Data.Entities
{
    public class BookingEntity : IEntity
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }

        public ServiceEntity Service { get; set; }
        public UserEntity User { get; set; }
    }
}
