using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Domain;

namespace MovieApp.Features.Genres;

public class GenreService
    : IGenreService
{
    private readonly MovieDbContext _context;

    public GenreService(MovieDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Genre>> GetAllGenresAsync()
    {
        return await _context.Genres.OrderBy(g => g.Title).ToListAsync();
    }

    public async Task<Genre> GetGenreAsync(int genreId)
    {
        return await _context.Genres.FirstOrDefaultAsync(g => g.Id == genreId);
    }
}

