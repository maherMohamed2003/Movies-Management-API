using MoviesAPI.Data;
using MoviesAPI.DTOs.Genre;
using MoviesAPI.Models;

namespace MoviesAPI.Services.GenreService
{
    public class GenreService : IGenreService
    {
        private readonly AppDbContext _db;

        public GenreService(AppDbContext db)
        {
            _db = db;
        }


        public List<Genre> Get()
        {
           var genres = _db.Genres.ToList();
            return genres;
        }

        public Genre GetGenreByID(int id)
        {
            var genre = _db.Genres.FirstOrDefault(x => x.Id == id);
            if (genre == null)
                return null;
            return genre;
        }

        public Genre Post(InsertGenre i)
        {
            Genre genre = new Genre
            {
                Name = i.name,
                Description = i.Description
            };
            _db.Genres.Add(genre);
            _db.SaveChanges();
            return genre;
        }

        public Genre Put(int id, UpdateGenre i)
        {
            var g = _db.Genres.FirstOrDefault(x => x.Id == id);
            if (g == null)
                return null;
            g.Description = i.Description;
            _db.SaveChanges();
            return g;
        }

        public Genre Delete(int id)
        {
            var g = _db.Genres.FirstOrDefault(x => x.Id == id);
            if (g == null)
                return null;
            _db.Genres.Remove(g);
            _db.SaveChanges();
            return g;
        }

    }
}
