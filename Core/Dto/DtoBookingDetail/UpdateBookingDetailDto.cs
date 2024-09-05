using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.DtoBookingDetail
{
    public class UpdateBookingDetailDto
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
    }
}
