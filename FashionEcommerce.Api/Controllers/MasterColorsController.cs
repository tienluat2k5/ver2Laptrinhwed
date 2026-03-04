using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;

namespace FashionEcommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterColorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MasterColorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.MasterColors.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(MasterColor color)
        {
            _context.MasterColors.Add(color);
            await _context.SaveChangesAsync();
            return Ok(color);
        }
    }
}