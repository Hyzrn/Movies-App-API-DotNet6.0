using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp.API.Entities;

namespace MoviesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> _logger;
        private readonly ApplicationDbContext _context;

        public GenresController(ILogger<GenresController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var genres = await _context.Genres.ToListAsync();
            return Ok(genres);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> Update(Genre genre)
        {
            _context.Update(genre);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
