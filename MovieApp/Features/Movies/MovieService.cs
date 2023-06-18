using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Domain;

namespace MovieApp.Features.Movies;

public class MovieService
    : IMovieService
{
    private readonly MovieDbContext _context;
    private readonly ILogger _logger;

    public MovieService(MovieDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    public void AddMovieToGenre(int genreId, Movie movie)
    {
        _logger.LogWarning($"{movie.Title}, {genreId} kategorisine eklenecek");
        movie.GenreId = genreId;
        _context.Movies.Add(movie);
    }

    public void DeleteMovie(Movie movie)
    {
        _logger.LogWarning($"{movie.Title} silinecek");
        _context.Movies.Remove(movie);
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesAsync(int genreId)
    {
        _logger.LogWarning($"{genreId} nolu türe ait filmler istendi");
        return await _context.Movies.Where(m => m.GenreId == genreId).OrderBy(m => m.Title).ToListAsync();
    }

    public async Task<Movie> GetMovieAsync(int movieId)
    {
        return await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
    }
}