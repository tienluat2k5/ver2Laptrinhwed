using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionEcommerce.Api.Data;
using FashionEcommerce.Api.Models;

namespace FashionEcommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCategorysController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ArticleCategorysController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.ArticleCategories.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArticleCategory category)
        {
            _context.ArticleCategories.Add(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }
    }
}