using ContactManagement.DAL.DbContext;
using ContactManagement.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ContactManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext context, ILogger<AuthController> logger, IConfiguration config)
        {
            _context = context;
            _logger = logger;
            _config = config;
        }

        // ✅ REGISTER DTO
        public record RegisterDto(string Username, string Password, string Role);

        // ✅ LOGIN DTO
        public record LoginDto(string Username, string Password);


        // 🔐 REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password))
                return BadRequest(new { message = "Username and Password are required" });

            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == model.Username);

            if (existingUser != null)
                return BadRequest(new { message = "User already exists" });

            _logger.LogInformation("Register attempt: {Username}", model.Username);

            var user = new User
            {
                Username = model.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                Role = string.IsNullOrEmpty(model.Role) ? "User" : model.Role
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            _logger.LogInformation("User registered successfully: {Username}", model.Username);

            return Ok(new { message = "User registered successfully" });
        }


        // 🔐 LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            _logger.LogInformation("Login attempt: {Username}", model.Username);

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == model.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                _logger.LogWarning("Invalid login attempt: {Username}", model.Username);
                return Unauthorized(new { message = "Invalid credentials" });
            }

            _logger.LogInformation("Login successful: {Username}", user.Username);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiry = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expires = expiry
            });
        }
    }
}