using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionEcommerce.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Checkout → tạo Order
        [HttpPost("checkout/{userId}")]
        public IActionResult Checkout(int userId)
        {
            var cartItems = _context.CartItems
                .Include(c => c.ProductVariant)
                .Where(c => c.UserId == userId)
                .ToList();

            if (!cartItems.Any())
                return BadRequest("Cart empty");

            var order = new Order
            {
                UserId = userId,
                Status = "Pending",
                CreatedAt = DateTime.Now,
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

        // 2. Lấy tất cả đơn
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _context.Orders
                .Include(o => o.OrderDetails)
                .ToList();

            return Ok(orders);
        }

        // 3. Lấy đơn theo user
        [HttpGet("user/{userId}")]
        public IActionResult GetUserOrders(int userId)
        {
            var orders = _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.UserId == userId)
                .ToList();

            return Ok(orders);
        }

        // 4. Update trạng thái đơn
        [HttpPut("status/{orderId}")]
        public IActionResult UpdateStatus(int orderId, [FromBody] string status)
        {
            var order = _context.Orders.Find(orderId);

            if (order == null)
                return NotFound();

            order.Status = status;

            _context.SaveChanges();

            return Ok(order);
        }
    }
}