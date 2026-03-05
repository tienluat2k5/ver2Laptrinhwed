using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;

namespace FashionEcommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {

            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] string? search)
        {
            var query = _context.Products.AsQueryable();

            // Nếu frontend có gửi từ khóa tìm kiếm lên
            if (!string.IsNullOrWhiteSpace(search))
            {
                // Lưu ý: Sửa chữ 'ProductName' thành đúng cái tên cột trong model Products của mày nhé
                query = query.Where(p => p.ProductName.Contains(search));
            }

            var products = await query.Take(20).ToListAsync();
            return Ok(products);
        }
    }
}