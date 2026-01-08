using Microsoft.AspNetCore.Mvc;
using MoviesAPI.DTOs.Genre;

namespace MoviesAPI.Services.GenreService
{
    public interface IGenreService
    {
        public List<Genre> Get();
        public Genre GetGenreByID(int id);

        public Genre Post(InsertGenre i);

        public Genre Put(int id,UpdateGenre i);

        public Genre Delete(int id);

    }
}
