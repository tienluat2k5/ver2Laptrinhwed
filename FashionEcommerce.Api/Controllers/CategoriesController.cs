using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionEcommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/Categories
        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        // PUT: api/Categories/5
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Category category)
        {
            if (id != category.Id)
            {
                return BadRequest("Id mismatch");
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Categories.Any(c => c.Id == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

