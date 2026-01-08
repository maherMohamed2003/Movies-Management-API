using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FSharp.Data.UnitSystems.SI.UnitNames;
using MoviesAPI.Data;
using MoviesAPI.DTOs.Movie;
using MoviesAPI.Models;
using MoviesAPI.Used_Methods;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public MoviesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _db.Movies.Include(x => x.Genre).ToList();
            return Ok(movies);
        }
        [HttpGet("{id}")]
        public IActionResult GetMovieByID(int id)
        {
            var m = _db.Movies
                       .Include(m => m.Genre).FirstOrDefault(x => x.Id == id);

            if (m == null)
                return NotFound($"Movie with ID {id} not found");

            var movie = new
            {
                Title = m.Title,
                Year = m.Year,
                Rate = m.Rate,
                Poster = m.Poster,
                GenreId = m.GenreId,
                GenreName = m.Genre?.Name
            };

            return Ok(movie);
        }


        [HttpGet("Genre/{Id}")]
        public IActionResult GetMoviesWithGenreID(int id)
        {
            var movies = _db.Movies.Include(x => x.Genre).Where(x => x.GenreId == id);
            if (movies == null)
                return BadRequest("This ID Is Not Exists!");
            return Ok(movies);
        }

        [HttpPost]
        public IActionResult Post(InsertMovie movie)
        {
            var sizeCheck = CheckImages.CkeckSize(movie.Poster);
            var typeCheck = CheckImages.CheckType(movie.Poster);
            if(sizeCheck == false || sizeCheck == false)
            {
                return BadRequest("The Poster Size Or Type In INVALID!!");
            }

            var stream = new MemoryStream();
            movie.Poster.CopyTo(stream);

            Movie newMovie = new Movie
            {
                Title = movie.Title,
                Poster = stream.ToArray(),
                Rate = movie.Rate,
                Year = movie.Year,
                GenreId = movie.GenreId
            };
            _db.Movies.Add(newMovie);
            _db.SaveChanges();
            return Ok(newMovie);
        }

        [HttpPut]
        public IActionResult Put(UpdateMovie update , int id)
        {
            var sizeCheck = CheckImages.CkeckSize(update.Poster);
            var typeCheck = CheckImages.CheckType(update.Poster);
            if (sizeCheck == false || sizeCheck == false)
            {
                return BadRequest("The Poster Size Or Type In INVALID!!");
            }
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound("This ID Is Not Exsits");
            var stream = new MemoryStream();
            update.Poster.CopyTo(stream);


            movie.Poster = stream.ToArray();
            movie.Rate = update.Rate;
            _db.SaveChanges();
            return Ok(movie);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound("This ID Is Not Exsits");
            _db.Movies.Remove(movie);
            _db.SaveChanges();
            return Ok(movie);
        }

    }
}
