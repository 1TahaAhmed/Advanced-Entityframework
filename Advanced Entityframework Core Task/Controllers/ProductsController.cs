using Advanced_Entityframework_Core_Task.AppDbContext;
using Advanced_Entityframework_Core_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advanced_Entityframework_Core_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products
                .AsNoTracking()
                .Select(x => new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category
                })
                .ToListAsync();

            return Ok(products);
        }
    }
}
