using Core.Dto.DtoBookingDetail;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ServiceBookingPlatformApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingDetailsController : ControllerBase
    {
        private readonly IBookingDetailService _bookingDetailService;

        public BookingDetailsController(IBookingDetailService bookingDetailService)
        {
            _bookingDetailService = bookingDetailService;
        }

        // Отримати всі деталі бронювання
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllBookingDetails()
        {
            var bookingDetails = await _bookingDetailService.GetAllBookingDetailsAsync();
            return Ok(bookingDetails);
        }

        // Отримати деталі бронювання за ID
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetBookingDetailById(int id)
        {
            var bookingDetail = await _bookingDetailService.GetBookingDetailByIdAsync(id);
            if (bookingDetail == null)
            {
                return NotFound("BookingDetail not found.");
            }
            return Ok(bookingDetail);
        }

        // Створити нову деталь бронювання
        [HttpPost("Create")]
        public async Task<IActionResult> CreateBookingDetail([FromBody] CreateBookingDetailDto createBookingDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _bookingDetailService.CreateBookingDetailAsync(createBookingDetailDto);
            return Ok();
        }

        // Оновити деталь бронювання
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBookingDetail([FromBody] UpdateBookingDetailDto updateBookingDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _bookingDetailService.UpdateBookingDetailAsync(updateBookingDetailDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("BookingDetail not found.");
            }
        }

        // Видалити деталь бронювання
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBookingDetail(int id)
        {
            try
            {
                await _bookingDetailService.DeleteBookingDetailAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("BookingDetail not found.");
            }
        }
    }
}
