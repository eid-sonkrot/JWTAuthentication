using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public UsersController(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Authenticate(string userName)
        {
            var token = _jwtTokenGenerator.GenerateToken(userName);

            if (token is null)
            {
                return Ok(new { Message = "Unauthorized" });
            }
            return Ok(token);
        }
    }
}