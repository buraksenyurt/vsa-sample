using MovieApp.Domain;

namespace MovieApp.Features.Genres;

public interface IGenreService
{
    Task<IEnumerable<Genre>> GetAllGenresAsync();
    Task<Genre> GetGenreAsync(int genreId);
}