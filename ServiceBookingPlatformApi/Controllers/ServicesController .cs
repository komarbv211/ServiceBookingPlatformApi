using Core.Dto.DtoServices;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ServiceBookingPlatformApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _serviceService.GetAllServicesAsync();
            return Ok(services);
        }

        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _serviceService.GetServiceByIdAsync(id);
            if (service == null)
            {
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);
            }
            return Ok(service);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceDto serviceDto)
        {
            var newServiceId = await _serviceService.CreateServiceAsync(serviceDto);
            return CreatedAtAction(nameof(GetServiceById), new { id = newServiceId }, serviceDto);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceDto serviceDto)
        {

            await _serviceService.UpdateServiceAsync(serviceDto);
            return NoContent();
        }

        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _serviceService.GetServiceByIdAsync(id);
            if (service == null)
            {
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);

            }

            await _serviceService.DeleteServiceAsync(id);
            return NoContent();
        }
        [HttpGet("GetByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetServicesByCategoryId(int categoryId)
        {
            var services = await _serviceService.GetServicesByCategoryIdAsync(categoryId);
            return Ok(services);
        }

        [HttpGet("GetByRating/{rating}")]
        public async Task<IActionResult> GetServicesByRating(int rating)
        {
            var services = await _serviceService.GetServicesByRatingAsync(rating);
            return Ok(services);
        }

        [HttpGet("GetByPriceRange/{minPrice}/{maxPrice}")]
        public async Task<IActionResult> GetServicesByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var services = await _serviceService.GetServicesByPriceRangeAsync(minPrice, maxPrice);
            return Ok(services);
        }
    }
}
