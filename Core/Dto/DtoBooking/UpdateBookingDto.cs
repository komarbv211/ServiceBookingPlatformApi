using Core.Dto.DtoBookingDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.DtoBooking
{
    public class UpdateBookingDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
    }
}
