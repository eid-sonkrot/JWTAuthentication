using Microsoft.Extensions.Configuration;

namespace JWTAuthentication
{
    public class Jwt:IJwt
    {
        private readonly IConfiguration _configuration;
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryInMinutes { get; set; }

        public Jwt(IConfiguration configuration)
        {
            _configuration = configuration;
            Issuer = _configuration["JWTToken:Issuer"];
            Audience = _configuration["JWTToken:Audience"];
            SecretKey = _configuration["JWTToken:key"];
            ExpiryInMinutes = int.Parse(_configuration["JWTToken:ExpiryInMinutes"]);
        }
    }
}