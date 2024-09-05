using Core.Dto.DtoBookingDetail;
using Core.Dto.DtoUser;

namespace Core.Dto.DtoBooking
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }

        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }

        public UserDto User { get; set; }
        public ICollection<BookingDetailDto> BookingDetails { get; set; }
    }
}
