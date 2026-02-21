using Microsoft.AspNetCore.Mvc;
using testapi.DB;
using testapi.Models;

namespace testapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IExchange _exchange;
        private AppDbContext AppDbContext;
        public ProductsController(IExchange exchange,AppDbContext context) :base()
        {
            _exchange = exchange;
            AppDbContext = context;
        }
        [HttpPost("exchange")]
        public async Task<IActionResult> GetExchangeRate(string currency)
        {
            var result = await _exchange.GetExchangeRate(currency);
            if (result != 0)
                return Ok(result);
            else
                return NotFound();
        }
        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct(string name, decimal price)
        {
            var product = new Product{ Name = name, Price = price };
            var prod = AppDbContext.Products.FirstOrDefault(u=> u.Name==product.Name);
            if (prod!=null)
                return BadRequest("Product already exists.");
            AppDbContext.Products.Add(product);
            await AppDbContext.SaveChangesAsync();
            return Ok(product);
        }
        [HttpPut("update-price")]
        public async Task<IActionResult> UpdatePrice(int id, decimal newPrice,int userID)
        {
            var user = AppDbContext.Users.FirstOrDefault(u => u.ID == userID);
            if (user == null)
                return NotFound("User not found.");
            if (user.AdminAcces == 0)
                return Forbid("User does not have admin access.");
            var product = AppDbContext.Products.FirstOrDefault(p => p.ID == id);
            if (product == null)
                return NotFound("Product not found.");
            product.Price = newPrice;
            await AppDbContext.SaveChangesAsync();
            return Ok(product);
        }
    }
}
