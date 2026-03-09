using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionEcommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductVariantsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductVariantsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductVariants
        [HttpGet]
        public IActionResult GetAll()
        {
            var variants = _context.ProductVariants.ToList();
            return Ok(variants);
        }

        // GET: api/ProductVariants/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var variant = _context.ProductVariants.Find(id);
            if (variant == null)
            {
                return NotFound();
            }

            return Ok(variant);
        }

        // POST: api/ProductVariants
        [HttpPost]
        public IActionResult Create([FromBody] ProductVariant variant)
        {
            if (variant == null)
            {
                return BadRequest();
            }

            _context.ProductVariants.Add(variant);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = variant.Id }, variant);
        }

        // PUT: api/ProductVariants/5
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] ProductVariant variant)
        {
            if (id != variant.Id)
            {
                return BadRequest("Id mismatch");
            }

            _context.Entry(variant).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ProductVariants.Any(v => v.Id == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/ProductVariants/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var variant = _context.ProductVariants.Find(id);
            if (variant == null)
            {
                return NotFound();
            }

            _context.ProductVariants.Remove(variant);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

