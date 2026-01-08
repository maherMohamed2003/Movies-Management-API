namespace MoviesAPI.DTOs.Movie
{
    public class InsertMovie
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public float Rate { get; set; }

        public IFormFile Poster { get; set; }

        public int GenreId { get; set; }
    }
}
