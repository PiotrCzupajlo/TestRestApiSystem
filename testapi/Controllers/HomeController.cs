using Microsoft.AspNetCore.Mvc;

namespace testapi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }
    }
}
