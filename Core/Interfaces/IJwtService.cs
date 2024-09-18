using Data.Entities;
using System.Security.Claims;

namespace Core.Interfaces
{
    public interface IJwtService
    {
        // ------- Access Token
        IEnumerable<Claim> GetClaims(UserEntity user);
        string CreateToken(IEnumerable<Claim> claims);

    }
}