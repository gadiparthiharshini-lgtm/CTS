using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAuthenticationAPI.Models;

namespace JWTAuthenticationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static readonly List<User> users = new()
        {
            new User
            {
                Username = "admin",
                Password = "admin123",
                Role = "Admin"
            },
            new User
            {
                Username = "user",
                Password = "user123",
                Role = "User"
            }
        };

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            var user = users.FirstOrDefault(x =>
                x.Username == login.Username &&
                x.Password == login.Password);

            if (user == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(jwt);
        }
    }
}