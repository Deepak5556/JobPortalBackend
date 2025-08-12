using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalBackend.Data;
using JobPortalBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace JobPortalBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly JobPortalContext _context;

        public UsersController(JobPortalContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            // Prevent NULL-to-string crash by projecting with null-coalescing
            var users = await _context.Users
                .Select(u => new User
                {
                    UserId = u.UserId,
                    Username = u.Username ?? string.Empty,
                    Email = u.Email ?? string.Empty,
                    Password = null, // never return password
                    PhoneNumber = u.PhoneNumber ?? string.Empty,
                    Role = u.Role ?? string.Empty
                })
                .ToListAsync();

            if (users == null || users.Count == 0)
                return NotFound(new { message = "No users found." });

            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            user.Password = null;
            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
                return BadRequest(new { message = "User ID mismatch" });

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                    return NotFound(new { message = "User not found" });
                else
                    throw;
            }

            return NoContent();
        }

        // POST: api/Users/Signup
        [HttpPost("Signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.Role) ||
                string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                return BadRequest(new { message = "All fields are required" });
            }

            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower());
            if (existingUser != null)
                return Conflict(new { message = "Email already registered" });

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password, 
                Role = request.Role,
                PhoneNumber = request.PhoneNumber
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            user.Password = null;
            return Ok(new { message = "Signup successful", user });
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Users/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest(new { message = "Email and password are required" });

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower());
            if (user == null)
                return NotFound(new { message = "Please create an account." });

            if (user.Password != request.Password)
                return Unauthorized(new { message = "Invalid password." });

            user.Password = null;
            return Ok(new { message = "Login successful", user });
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }

    // DTOs
    public class SignupRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
