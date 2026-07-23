using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTRoleBasedAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return Ok("Welcome Admin! This is a role-protected endpoint.");
        }
    }
}