using Microsoft.AspNetCore.Mvc;

namespace testapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }
    }
}
