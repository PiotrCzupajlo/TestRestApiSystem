using Microsoft.AspNetCore.Mvc;
using testapi.DB;
using testapi.Models;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> LogIn(LogInUser user)
        {
            string regexPattern = @"^[\w\.]+@[\w]+\.[\w]+$"; 
            bool isValid = Regex.IsMatch(user.email, regexPattern);
            if (!isValid)
            {
                return BadRequest("Invalid email format.");
            }
            var user_n = _context.Users.FirstOrDefault(u => u.Email == user.email && u.Password == user.password);
            if (user_n != null)
                return Ok("{\"ID\":\"" + user_n.ID+"\"}");
            else
                return NotFound("User Not Found");
        }
        [HttpPost("insert-user")]
        public async Task<IActionResult> AddUser(RegisterUser user)
        {
            var new_user = new User
            {
                Name = user.name,
                Email = user.email,
                Password = user.password,
                AdminAcces=0
                
            };
            if(user.password.Length<8)
            {
                return BadRequest("Password must be at least 8 characters long.");
            }
            string regexpattern = @"^[\w\.]+@[\w]+\.[\w]+$";
            bool isValid = Regex.IsMatch(user.email, regexpattern);
            if (!isValid)
            { 
            return BadRequest("Invalid email format.");
            }
            _context.Users.Add(new_user);
            await _context.SaveChangesAsync();
            return Ok("{}");
        
        }
        [HttpPost("get-name-by-id")]
        public async Task<IActionResult> GetNameById(OnlyId id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.ID == id.id);
            if (user == null)
                return BadRequest("{\"Reason\":\"Wrong Id}");
            else
                return Ok("{\"name\":\""+user.Name+"\"}");
        
        
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
