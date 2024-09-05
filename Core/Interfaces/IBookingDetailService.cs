using Core.Dto.DtoBooking;
using Core.Dto.DtoBookingDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBookingDetailService
    {
        Task<IEnumerable<BookingDetailDto>> GetAllBookingDetailsAsync();
        Task<BookingDetailDto> GetBookingDetailByIdAsync(int id);
        Task CreateBookingDetailAsync(CreateBookingDetailDto createBookingDetailDto);
        Task UpdateBookingDetailAsync(UpdateBookingDetailDto updateBookingDetailDto);
        Task DeleteBookingDetailAsync(int id);
    }
}
