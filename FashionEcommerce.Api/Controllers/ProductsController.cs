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

        // GET: api/Products
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products
                .Include(p => p.Variants)
                .ToList();

            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products
                .Include(p => p.Variants)
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return BadRequest("Name is required");
            }

            product.Slug = product.Name
                .ToLower()
                .Replace(" ", "-");

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Id mismatch");
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return BadRequest("Name is required");
            }

            // Regenerate slug when name changes
            product.Slug = product.Name
                .ToLower()
                .Replace(" ", "-");

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(p => p.Id == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}