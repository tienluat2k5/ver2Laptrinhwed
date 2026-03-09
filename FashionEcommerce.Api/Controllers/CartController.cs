using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.DTOs;
using FashionEcommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionEcommerce.Api.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Lấy giỏ hàng
        [HttpGet("{userId}")]
        public IActionResult GetCart(int userId)
        {
            var cart = _context.CartItems
                .Include(c => c.ProductVariant)
                .Where(c => c.UserId == userId)
                .ToList();

            return Ok(cart);
        }

        // 2. Thêm vào giỏ
        [HttpPost("add")]
        public IActionResult AddToCart([FromBody] CartItemAddDto dto)
        {
            var existing = _context.CartItems
                .FirstOrDefault(c => c.UserId == dto.UserId && c.ProductVariantId == dto.ProductVariantId);

            if (existing != null)
            {
                existing.Quantity += dto.Quantity;
            }
            else
            {
                // Create new CartItem without ProductVariant to avoid issues
                var newItem = new CartItem
                {
                    UserId = dto.UserId,
                    ProductVariantId = dto.ProductVariantId,
                    Quantity = dto.Quantity
                };
                _context.CartItems.Add(newItem);
            }

            _context.SaveChanges();

            return Ok("Added to cart");
        }

        // 3. Xóa sản phẩm khỏi giỏ
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var item = _context.CartItems.Find(id);

            if (item == null)
                return NotFound();

            _context.CartItems.Remove(item);
            _context.SaveChanges();

            return Ok("Removed");
        }

        // 4. Xóa toàn bộ giỏ
        [HttpDelete("clear/{userId}")]
        public IActionResult ClearCart(int userId)
        {
            var items = _context.CartItems.Where(c => c.UserId == userId);

            _context.CartItems.RemoveRange(items);
            _context.SaveChanges();

            return Ok("Cart cleared");
        }
    }
}