using Core.Dto.DtoBooking;
using Core.Exceptions;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ServiceBookingPlatformApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("GetAllWithDetails")]
        public async Task<IActionResult> GetAllBookingsWithDetails()
        {
            var bookings = await _bookingService.GetAllBookingsAndBookingDetailAsync();
            return Ok(bookings);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                throw new HttpException("Booking not found!", HttpStatusCode.NotFound);
            }
            return Ok(booking);
        }

        [HttpGet("GetByIdWithDetails/{id}")]
        public async Task<IActionResult> GetBookingByIdWithDetails(int id)
        {
            var booking = await _bookingService.GetBookingByIdAndBookingDetailAsync(id);
            if (booking == null)
            {
                throw new HttpException("Booking not found!", HttpStatusCode.NotFound);
            }
            return Ok(booking);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto createBookingDto)
        {
            await _bookingService.CreateBookingAsync(createBookingDto);

            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBooking([FromBody] UpdateBookingDto updateBookingDto)
        {
            await _bookingService.UpdateBookingAsync(updateBookingDto);
            return NoContent();
        }

        [HttpPatch("payStatus/{id}")]
        public async Task<IActionResult> MarkAsPaid(int id, string PaidStatus)
        {
            var existingBooking = await _bookingService.GetBookingByIdAsync(id);
            if (existingBooking == null)
            {
                throw new HttpException("Booking not found!", HttpStatusCode.NotFound);
            }

            await _bookingService.UpdatePaymentStatusAsync(id, PaidStatus);
            return NoContent();
        }

        [HttpPatch("refund/{id}")]
        public async Task<IActionResult> MarkAsRefunded(int id)
        {
            var existingBooking = await _bookingService.GetBookingByIdAsync(id);
            if (existingBooking == null)
            {
                throw new HttpException("Booking not found!", HttpStatusCode.NotFound);
            }

            await _bookingService.UpdatePaymentStatusAsync(id, "Refunded");
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {

            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                throw new HttpException("Booking not found!", HttpStatusCode.NotFound);
            }
                await _bookingService.DeleteBookingAsync(id);
                return NoContent();
        }
    }
}
