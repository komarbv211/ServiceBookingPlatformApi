﻿using Core.Dto.DtoBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto> GetBookingByIdAsync(int id);
        Task<int> CreateBookingAsync(CreateBookingDto createBookingDto);
        Task UpdateBookingAsync(UpdateBookingDto updateBookingDto);
        Task UpdatePaymentStatusAsync(int id, string status);
        Task DeleteBookingAsync(int id);
    }
}