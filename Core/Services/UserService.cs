using AutoMapper;
using Core.Dto.DtoUser;
using Core.Interfaces;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetByID(id);
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            return _mapper.Map<UserDto>(user);
        }

        public async Task<string> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<UserEntity>(createUserDto);
            await _userRepository.Insert(user);
            await _userRepository.Save();
            return user.Id;
        }

        public async Task UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetByID(updateUserDto.Id);
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            _mapper.Map(updateUserDto, user);
            await _userRepository.Update(user);
            await _userRepository.Save();
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _userRepository.GetByID(id);
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            await _userRepository.Delete(user);
            await _userRepository.Save();
        }
    }
}
