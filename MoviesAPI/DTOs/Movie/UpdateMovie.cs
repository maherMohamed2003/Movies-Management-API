namespace MoviesAPI.DTOs.Movie
{
    public class UpdateMovie
    {
        public float Rate { get; set; }

        public IFormFile Poster { get; set; }
    }
}
