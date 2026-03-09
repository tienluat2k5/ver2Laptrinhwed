using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionEcommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _context.Orders
                .Include(o => o.OrderDetails)
                .ToList();

            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (order.OrderDetails == null || !order.OrderDetails.Any())
            {
                return BadRequest("Order must have at least one detail item");
            }

            order.CreatedAt = DateTime.UtcNow;

            _context.Orders.Add(order);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        // PUT: api/Orders/5
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Order order)
        {
            if (id != order.Id)
            {
                return BadRequest("Id mismatch");
            }

            _context.Entry(order).State = EntityState.Modified;

            // Update child collection
            if (order.OrderDetails != null)
            {
                foreach (var detail in order.OrderDetails)
                {
                    if (detail.Id == 0)
                    {
                        _context.Entry(detail).State = EntityState.Added;
                    }
                    else
                    {
                        _context.Entry(detail).State = EntityState.Modified;
                    }
                }
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Orders.Any(o => o.Id == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            // Remove child details first if needed
            if (order.OrderDetails != null && order.OrderDetails.Any())
            {
                _context.OrderDetails.RemoveRange(order.OrderDetails);
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return NoContent();
        }

        // 1. Checkout → tạo Order từ giỏ hàng
        [HttpPost("checkout/{userId}")]
        public IActionResult Checkout(int userId)
        {
            var cartItems = _context.CartItems
                .Include(c => c.ProductVariant)
                .Where(c => c.UserId == userId)
                .ToList();

            if (!cartItems.Any())
            {
                return BadRequest("Cart empty");
            }

            var order = new Order
            {
                UserId = userId,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var item in cartItems)
            {
                order.OrderDetails.Add(new OrderDetail
                {
                    ProductVariantId = item.ProductVariantId,
                    Quantity = item.Quantity,
                    Price = item.ProductVariant.PriceModifier
                });
            }

            _context.Orders.Add(order);

            // clear cart
            _context.CartItems.RemoveRange(cartItems);

            _context.SaveChanges();

            return Ok(order);
        }

        // 2. Lấy đơn theo user
        [HttpGet("user/{userId:int}")]
        public IActionResult GetUserOrders(int userId)
        {
            var orders = _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.UserId == userId)
                .ToList();

            return Ok(orders);
        }

        // 3. Update trạng thái đơn
        [HttpPut("status/{orderId:int}")]
        public IActionResult UpdateStatus(int orderId, [FromBody] string status)
        {
            var order = _context.Orders.Find(orderId);

            if (order == null)
            {
                return NotFound();
            }

            order.Status = status;

            _context.SaveChanges();

            return Ok(order);
        }
    }
}