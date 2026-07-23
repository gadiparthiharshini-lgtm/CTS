using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTUnauthorizedAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetSecureData()
        {
            return Ok("You are authorized to access this secure endpoint.");
        }
    }
}