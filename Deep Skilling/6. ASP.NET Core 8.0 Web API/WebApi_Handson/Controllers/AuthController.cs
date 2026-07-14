using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi_Handson.Controllers;

// Hands-on 5: issues JWTs. Marked [AllowAnonymous] because callers need to be
// able to obtain a token before they are authenticated. The issuer, audience
// and signing key MUST match the validation parameters configured in Program.cs.
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    // GET api/auth?userId=1&userRole=Admin
    // Generates a token carrying the role claim so the EmployeeController's
    // [Authorize(Roles = "POC,Admin")] check can succeed.
    [HttpGet]
    public IActionResult Get(int userId = 1, string userRole = "Admin")
    {
        var token = GenerateJSONWebToken(userId, userRole);
        return Ok(new { token });
    }

    private string GenerateJSONWebToken(int userId, string userRole)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Role, userRole),
            new Claim("UserId", userId.ToString())
        };

        // The "expires" attribute controls how long the token is valid. Change
        // AddMinutes(10) to AddMinutes(2) to observe 401 responses after expiry.
        var token = new JwtSecurityToken(
            issuer: "mySystem",
            audience: "myUsers",
            claims: claims,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
