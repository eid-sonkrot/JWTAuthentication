using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        [Authorize]
        [HttpGet("welcome")]
        public IActionResult GetWelcomeMessage()
        {
            return Ok(new { Message = "Hi man" });
        }
    }
}