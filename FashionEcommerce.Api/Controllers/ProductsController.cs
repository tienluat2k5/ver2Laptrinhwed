using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionEcommerce.Api.Models;
using FashionEcommerce.Api.Data;

namespace FashionEcommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products
                .Include(p => p.Variants)
                .ToList();

            return Ok(products);
        }

        [HttpPost]
public IActionResult Create(Product product)
{
    // Kiểm tra Name
    if (string.IsNullOrEmpty(product.Name))
        return BadRequest("Name is required");

    // Tạo slug tự động
    product.Slug = product.Name
        .ToLower()
        .Replace(" ", "-");

    _context.Products.Add(product);
    _context.SaveChanges();

    return Ok(product);
}
    }}