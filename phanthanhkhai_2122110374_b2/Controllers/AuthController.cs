using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using phanthanhkhai_2122110374_b2.Data;
using phanthanhkhai_2122110374_b2.Model;
<<<<<<< HEAD
using BCrypt.Net; // Thư viện BCrypt
=======
>>>>>>> 089519067c6c5c95a653b64ae86d63b6c8803143

namespace phanthanhkhai_2122110374_b2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

<<<<<<< HEAD
        // Đăng nhập
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.Email) || string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest("Email và mật khẩu không được để trống.");
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == loginModel.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password))
            {
                return Unauthorized("Thông tin đăng nhập không hợp lệ.");
            }

            var token = GenerateJwtToken(user);
            return Ok(new
            {
                token,
                username = user.Username,
                email = user.Email,
                name = user.Name
            });
        }

        // Tạo JWT Token
=======
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == loginModel.Username && u.Password == loginModel.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

>>>>>>> 089519067c6c5c95a653b64ae86d63b6c8803143
        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
<<<<<<< HEAD
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
=======
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
>>>>>>> 089519067c6c5c95a653b64ae86d63b6c8803143
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
<<<<<<< HEAD

        // Lấy tất cả username
        [HttpGet("names")]
        public IActionResult GetAllUsernames()
        {
            var names = _context.Users
                .Select(u => u.Name)
                .ToList();

            return Ok(names);
        }

        // Lấy username theo id
        [HttpGet("name/{id}")]
        public IActionResult GetUsernameById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("Không tìm thấy người dùng.");
            }

            return Ok(new { user.Name });
        }
    }

    // Model truyền vào khi đăng nhập
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
=======
    }

    // Model cho login
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
>>>>>>> 089519067c6c5c95a653b64ae86d63b6c8803143
