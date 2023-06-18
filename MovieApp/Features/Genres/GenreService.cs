using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Domain;

namespace MovieApp.Features.Genres;

public class GenreService
    : IGenreService
{
    private readonly MovieDbContext _context;
    private readonly ILogger _logger;

    public GenreService(MovieDbContext context,ILogger logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<IEnumerable<Genre>> GetAllGenresAsync()
    {
        _logger.LogWarning("Tüm film türleri istendi");
        return await _context.Genres.OrderBy(g => g.Title).ToListAsync();
    }

    public async Task<Genre> GetGenreAsync(int genreId)
    {
        _logger.LogWarning($"{genreId} türüne ait bilgi istendi");
        return await _context.Genres.FirstOrDefaultAsync(g => g.Id == genreId);
    }
}

