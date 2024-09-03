
namespace Core.Dto
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }

        public ServiceDto Service { get; set; }
        public UserDto User { get; set; }
    }
}
