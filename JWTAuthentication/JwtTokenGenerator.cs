using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthentication
{
    public class JwtTokenGenerator:IJwtTokenGenerator
    {
        private readonly string secretKey;
        private readonly string issuer;
        private readonly string audience;
        private readonly int expiryInMinutes;

        public JwtTokenGenerator(IJwt jwt)
        {
            issuer = jwt.Issuer;
            audience = jwt.Audience;
            secretKey = jwt.SecretKey;
            expiryInMinutes =jwt.ExpiryInMinutes;
        }
        public string GenerateToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}