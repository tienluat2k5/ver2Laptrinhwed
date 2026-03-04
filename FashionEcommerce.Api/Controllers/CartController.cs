using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;

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

        //GET CART
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var cart = await _context.CartItems
                .Where(c => c.UserId == userId)
                .ToListAsync();

            return Ok(cart);
        }

        //ADD TO CART
        [HttpPost]
        public async Task<IActionResult> AddToCart(CartItem item)
        {
            var existing = await _context.CartItems.FirstOrDefaultAsync(c =>
                c.UserId == item.UserId &&
                c.ProductVariantId == item.ProductVariantId);

            if (existing != null)
            {
                existing.Quantity += item.Quantity;
            }
            else
            {
                _context.CartItems.Add(item);
            }

            await _context.SaveChangesAsync();

            return Ok("Added to cart");
        }

        //UPDATE CART
        // UPDATE CART ITEM
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(int id, CartItem item)
        {
            var cart = await _context.CartItems.FindAsync(id);

            if (cart == null)
                return NotFound("Không tìm thấy cart item");

            cart.Quantity = item.Quantity;
            cart.ProductVariantId = item.ProductVariantId;
            cart.ProductId = item.ProductId;

            await _context.SaveChangesAsync();

            return Ok(cart);
        }

        //DELETE ITEM 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var cart = await _context.CartItems.FindAsync(id);

            if (cart == null)
                return NotFound();

            _context.CartItems.Remove(cart);
            await _context.SaveChangesAsync();

            return Ok("Deleted");
        }

        //CLEAR CART
        [HttpDelete("clear/{userId}")]
        public async Task<IActionResult> ClearCart(int userId)
        {
            var items = await _context.CartItems
                .Where(c => c.UserId == userId)
                .ToListAsync();

            _context.CartItems.RemoveRange(items);
            await _context.SaveChangesAsync();

            return Ok("Cart cleared");
        }
    }
}