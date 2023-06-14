using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Domain;

namespace MovieApp.Features.Movies;

public class MovieService
    : IMovieService
{
    private readonly MovieDbContext _context;

    public MovieService(MovieDbContext context)
    {
        _context = context;
    }

    public void AddMovieToGenre(int genreId, Movie movie)
    {
        movie.GenreId = genreId;
        _context.Movies.Add(movie);
    }

    public void DeleteMovie(int movieId)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
        if (movie != null)
            _context.Remove(movie);
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesAsync(int genreId)
    {
        return await _context.Movies.Where(m => m.GenreId == genreId).OrderBy(m => m.Title).ToListAsync();
    }

    public async Task<Movie> GetMovieAsync(int movieId)
    {
        return await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
    }
}