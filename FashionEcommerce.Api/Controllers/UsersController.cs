using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionEcommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.FullName))
            {
                return BadRequest("Email and FullName are required");
            }

            if (string.IsNullOrWhiteSpace(user.Role))
            {
                user.Role = "User";
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest("Id mismatch");
            }

            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.FullName))
            {
                return BadRequest("Email and FullName are required");
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(u => u.Id == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

