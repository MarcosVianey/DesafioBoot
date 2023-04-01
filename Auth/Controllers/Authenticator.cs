using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authenticator : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Authenticator(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (existingUser == null)
            {
                return Unauthorized();
            }

            var token = GenerateToken(existingUser);

            return Ok(new { Token = token });
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key"));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var input = user.Email + DateTime.Now;
            string hash;
            
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                hash = builder.ToString();
            }

            return hash;
        }
    }
}