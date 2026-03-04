using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;

namespace FashionEcommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PromotionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Promotions.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Promotion promo)
        {
            _context.Promotions.Add(promo);
            await _context.SaveChangesAsync();
            return Ok(promo);
        }
    }
}