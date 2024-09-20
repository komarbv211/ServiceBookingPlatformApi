using Core.Dto.DtoUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        Task<UserDto> GetUserByIdAsync(string id);

        Task<string> CreateUserAsync(CreateUserDto createUserDto);

        Task UpdateUserAsync(UpdateUserDto updateUserDto);

        Task DeleteUserAsync(string id);

        Task<IEnumerable<UserDto>> GetUsersByRoleAsync(string role);
        Task<IEnumerable<UserDto>> GetUsersByRegistrationDateAsync(DateTime startDate, DateTime endDate);
    }
}
