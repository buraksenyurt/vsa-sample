using MovieApp.Domain;

namespace MovieApp.Features.Movies;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllMoviesAsync(int genreId);
    Task<Movie> GetMovieAsync(int movieId);
    void AddMovieToGenre(int genreId, Movie movie);
    void DeleteMovie(int movieId);
}