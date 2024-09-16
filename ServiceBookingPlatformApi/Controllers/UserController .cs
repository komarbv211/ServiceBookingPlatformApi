using Core.Dto.DtoUser;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ServiceBookingPlatformApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (KeyNotFoundException)
            {
                throw new HttpException("User not found!", HttpStatusCode.NotFound);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            var newUserId = await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = newUserId }, userDto);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userDto)
        {
            try
            {
                await _userService.UpdateUserAsync(userDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                throw new HttpException("User not found!", HttpStatusCode.NotFound);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                throw new HttpException("User not found!", HttpStatusCode.NotFound);
            }
        }
    }
}
