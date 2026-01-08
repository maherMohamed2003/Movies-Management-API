using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.DTOs.Genre;
using MoviesAPI.Services.GenreService;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var genres = _genreService.Get();  
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreByID(int id)
        {
           var genre = _genreService.GetGenreByID(id);
            return Ok(genre);
        }

        [HttpPost]
        public IActionResult Post(InsertGenre i)
        {
            var genre = _genreService.Post(i);
            return Ok(genre);
        }

        [HttpPut]
        public IActionResult Put(int id , [FromBody]UpdateGenre i)
        {
            var g = _genreService.Put(id, i);
            return Ok(g);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var g = _genreService.Delete(id);
            return Ok(g);
        }
    }
}
