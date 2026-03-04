using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;

namespace FashionEcommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderDetailController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/OrderDetail
        [HttpGet]
        public async Task<IActionResult> GetDetails()
        {
            var details = await _context.OrderDetails
                .Include(d => d.Order)
                .ToListAsync();

            return Ok(details);
        }

        // POST api/OrderDetail
        [HttpPost]
        public async Task<IActionResult> AddDetail(OrderDetail detail)
        {
            var orderExists = await _context.Orders
                .AnyAsync(o => o.Id == detail.OrderId);

            if (!orderExists)
                return BadRequest("OrderId không tồn tại");

            _context.OrderDetails.Add(detail);
            await _context.SaveChangesAsync();

            return Ok(detail);
        }

        // DELETE api/OrderDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetail(int id)
        {
            var detail = await _context.OrderDetails.FindAsync(id);

            if (detail == null)
                return NotFound();

            _context.OrderDetails.Remove(detail);
            await _context.SaveChangesAsync();

            return Ok("Deleted");
        }
    }
}