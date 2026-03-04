using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;

namespace FashionEcommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterSizesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MasterSizesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.MasterSizes.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(MasterSize size)
        {
            _context.MasterSizes.Add(size);
            await _context.SaveChangesAsync();
            return Ok(size);
        }
    }
}