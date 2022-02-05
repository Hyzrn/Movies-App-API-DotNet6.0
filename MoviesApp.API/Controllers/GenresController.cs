using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.API.Entities;

namespace MoviesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var genres = new List<Genre>()
            {
                new Genre()
                {
                     Id = 1,
                     Name = "Comedy"
                },
                new Genre()
                {
                     Id = 2,
                     Name = "Drama"
                }
            };
            return Ok(genres);
        }

        [HttpPost]
        public IActionResult Add(Genre genre)
        {
            return Ok();
        }
    }
}
