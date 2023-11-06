using System.Security.Claims;

namespace JWTAuthentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username);
    }
}