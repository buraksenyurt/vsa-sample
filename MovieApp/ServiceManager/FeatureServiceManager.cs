using MovieApp.Data;
using MovieApp.Features.Genres;
using MovieApp.Features.Movies;

namespace MovieApp.ServiceManager;

public class FeatureServiceManager
    : IFeatureServiceManager
{
    private readonly MovieDbContext _context;
    private IGenreService _genreService;
    private IMovieService _movieService;

    public FeatureServiceManager(MovieDbContext context)
    {
        _context = context;
    }

    public IGenreService Genre => _genreService == null ? new GenreService(_context) : _genreService;

    public IMovieService Movie => _movieService == null ? new MovieService(_context) : _movieService;

    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}