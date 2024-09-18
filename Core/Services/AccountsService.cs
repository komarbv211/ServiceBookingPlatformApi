using AutoMapper;
using Core.Dto.DtoAuthorization;
using Core.Exceptions;
using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Security.Claims;

namespace Core.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public AccountsService(UserManager<UserEntity> userManager, IMapper mapper, IJwtService jwtService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtService = jwtService;
        }
        public async Task Register(RegisterDto model)
        {
            var user = _mapper.Map<UserEntity>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                //string all = string.Join(" ", result.Errors.Select(x => x.Description));
                var error = result.Errors.First();
                throw new HttpException(error.Description, HttpStatusCode.BadRequest);
            }
        }

        public async Task<LoginResponse> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                throw new HttpException("Invalid login or password.", HttpStatusCode.BadRequest);
            }

            var roles = await _userManager.GetRolesAsync(user); // Отримуємо ролі користувача
            var claims = _jwtService.GetClaims(user).ToList();

            // Додаємо ролі в claims
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return new LoginResponse
            {
                Token = _jwtService.CreateToken(claims)
            };
        }
        public async Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
