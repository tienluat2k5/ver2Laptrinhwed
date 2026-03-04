using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;

namespace FashionEcommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionConditionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PromotionConditionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.PromotionConditions.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PromotionCondition condition)
        {
            _context.PromotionConditions.Add(condition);
            await _context.SaveChangesAsync();
            return Ok(condition);
        }
    }
}