using Microsoft.Extensions.Logging.Console;
using MovieApp.Data;
using MovieApp.Features.Genres;
using MovieApp.Features.Movies;

namespace MovieApp.ServiceManager;

public class FeatureServiceManager
    : IFeatureServiceManager
{
    private readonly MovieDbContext _context;
    private readonly ILoggerFactory _loggerFactory;
    private IGenreService _genreService;
    private IMovieService _movieService;

    public FeatureServiceManager(MovieDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        _loggerFactory = loggerFactory;
    }

    public IGenreService Genre => _genreService == null ? new GenreService(_context, _loggerFactory.CreateLogger<GenreService>()) : _genreService;

    public IMovieService Movie => _movieService == null ? new MovieService(_context, _loggerFactory.CreateLogger<MovieService>()) : _movieService;

    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}