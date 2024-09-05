using Core.Dto.DtoBooking;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto createBookingDto)
        {
            if (createBookingDto == null)
            {
                return BadRequest();
            }

            var newBookingId = await _bookingService.CreateBookingAsync(createBookingDto);

            return CreatedAtAction(nameof(GetBookingById), new { id = newBookingId }, createBookingDto);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateBookingDto updateBookingDto)
        {
            if (id != updateBookingDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _bookingService.UpdateBookingAsync(updateBookingDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPatch("pay/{id}")]
        public async Task<IActionResult> MarkAsPaid(int id)
        {
            try
            {
                await _bookingService.UpdatePaymentStatusAsync(id, "Paid");
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpPatch("refund/{id}")]

        public async Task<IActionResult> MarkAsRefunded(int id)
        {
            try
            {
                await _bookingService.UpdatePaymentStatusAsync(id, "Refunded");
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            try
            {
                await _bookingService.DeleteBookingAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
