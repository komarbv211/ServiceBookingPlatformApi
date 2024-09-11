using Core.Dto.DtoBooking;
using Core.Exceptions;
using Core.Interfaces;
using Core.Services;
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);
            }
            return Ok(booking);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto createBookingDto)
        {
            var newBookingId = await _bookingService.CreateBookingAsync(createBookingDto);

            return CreatedAtAction(nameof(GetBookingById), new { id = newBookingId }, createBookingDto);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateBookingDto updateBookingDto)
        {
            if (id != updateBookingDto.Id)
            {
                return BadRequest("ID in the URL does not match the ID in the body.");
            }

            var existingBooking = await _bookingService.GetBookingByIdAsync(id);
            if (existingBooking == null)
            {
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);
            }

            await _bookingService.UpdateBookingAsync(updateBookingDto);
            return NoContent();
        }

        [HttpPatch("pay/{id}")]
        public async Task<IActionResult> MarkAsPaid(int id)
        {
            var existingBooking = await _bookingService.GetBookingByIdAsync(id);
            if (existingBooking == null)
            {
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);
            }

            await _bookingService.UpdatePaymentStatusAsync(id, "Paid");
            return NoContent();
        }

        [HttpPatch("refund/{id}")]
        public async Task<IActionResult> MarkAsRefunded(int id)
        {
            var existingBooking = await _bookingService.GetBookingByIdAsync(id);
            if (existingBooking == null)
            {
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);
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
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);
            }
                await _bookingService.DeleteBookingAsync(id);
                return NoContent();
        }
    }
}
