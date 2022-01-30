using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.API.Entities;

namespace MoviesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(Genre genre)
        {
            throw new ApplicationException();
            return Ok();
        }
    }
}
