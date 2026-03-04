using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;

namespace FashionEcommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(d => d.ProductVariant)
                .ToListAsync();

            return Ok(orders);
        }

        //GET(id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(d => d.ProductVariant)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                return NotFound("Không tìm thấy đơn hàng");

            return Ok(order);
        }

        //  CREATE ORDER (TEST)
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            order.OrderCode = "ORD" + DateTime.Now.Ticks;
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";
            order.PaymentStatus = "Pending";

            if (order.OrderDetails == null || !order.OrderDetails.Any())
                return BadRequest("Order phải có sản phẩm");

            decimal total = 0;

            foreach (var detail in order.OrderDetails)
            {
                total += detail.UnitPrice * detail.Quantity;
            }

            order.TotalAmount = total;
            order.DiscountAmount = 0;
            order.FinalAmount = total;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        //DELETE ORDER
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound("Không tìm thấy đơn");

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok("Đã xóa");
        }

        //CHECKOUT 
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(CheckoutDto dto)
        {
            // Lấy cart theo user
            var cartItems = await _context.CartItems
                .Where(c => c.UserId == dto.UserId)
                .ToListAsync();

            if (cartItems == null || !cartItems.Any())
                return BadRequest("Giỏ hàng trống");

            var order = new Order
            {
                OrderCode = "ORD" + DateTime.Now.Ticks,
                UserId = dto.UserId,
                OrderDate = DateTime.Now,
                ShippingName = dto.ShippingName,
                ShippingAddress = dto.ShippingAddress,
                ShippingPhone = dto.ShippingPhone,
                PaymentMethod = dto.PaymentMethod,
                PaymentStatus = "Pending",
                Status = "Pending",
                OrderDetails = new List<OrderDetail>()
            };

            decimal total = 0;

            foreach (var item in cartItems)
            {
                var variant = await _context.ProductVariants
                    .Include(v => v.Product)
                    .FirstOrDefaultAsync(v => v.Id == item.ProductVariantId);

                if (variant == null)
                    return BadRequest($"Variant {item.ProductVariantId} không tồn tại");

                if (variant.Quantity < item.Quantity)
                    return BadRequest($"Sản phẩm {variant.SKU} không đủ hàng");

                // Giá = giá sản phẩm + modifier
                var price = (variant.Product?.Price ?? 0) + variant.PriceModifier;

                var detail = new OrderDetail
                {
                    ProductVariantId = variant.Id,
                    Snapshot_ProductName = variant.Product?.Name ?? "",
                    Snapshot_Sku = variant.SKU ?? "",
                    Quantity = item.Quantity,
                    UnitPrice = price
                };

                // TRỪ KHO
                variant.Quantity -= item.Quantity;

                total += detail.Quantity * detail.UnitPrice;
                order.OrderDetails.Add(detail);
            }

            order.TotalAmount = total;
            order.DiscountAmount = 0;
            order.FinalAmount = total;

            // Lưu order
            _context.Orders.Add(order);

            // XÓA CART
            _context.CartItems.RemoveRange(cartItems);

            await _context.SaveChangesAsync();

            return Ok(order);
        }
    }
}