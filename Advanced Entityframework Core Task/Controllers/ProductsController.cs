using Advanced_Entityframework_Core_Task.AppDbContext;
using Advanced_Entityframework_Core_Task.DTOs;
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
        public async Task<IActionResult> GetProducts(int pageNumber = 1, int pageSize = 10)
        {
            var products = await _context.Products
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Price,
                    CategoryName = x.Category != null ? x.Category.Electronics : "Categoryyy Electronicsss"
                })
                .ToListAsync();

            return Ok(products);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto dto)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
            {
                return NotFound(new { message = "Product not found." });
            }
            product.Name = dto.Name;
            product.Price = dto.Price;
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Product updated successfully.", product });
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "The product has been modified by another user. Please reload and try again." });
            }
        }
    }
}