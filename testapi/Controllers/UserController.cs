using Microsoft.AspNetCore.Mvc;
using testapi.DB;
using testapi.Models;
using System.Text.RegularExpressions;
namespace testapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("login-user")]
        public async Task<IActionResult> logIn(string email,string password)
        {
            string regexPattern = @"[^;]"; //anti sql injection
            bool isValid = Regex.IsMatch(email, regexPattern);
            if (!isValid)
            {
                return BadRequest("Invalid email format.");
            }
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
                return Ok("User Found:" + user.ID);
            else
                return NotFound("User Not Found");
        }
        [HttpPost("insert-user")]
        public async Task<IActionResult> AddUser(string name, string email, string password)
        {
            var user = new User
            {
                Name = name,
                Email = email,
                Password = password,
                AdminAcces=0
                
            };
            if(password.Length<8)
            {
                return BadRequest("Password must be at least 8 characters long.");
            }
            string regexpattern = @"^[\w\.]+@[\w]+\.[\w]+$";
            bool isValid = Regex.IsMatch(email, regexpattern);
            if (!isValid)
            { 
            return BadRequest("Invalid email format.");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("Succes");
        
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Example");
        
        }
        [HttpPut]
        public IActionResult Put()
        {
            return NoContent();

        }
    }
}
