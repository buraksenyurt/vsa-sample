using Microsoft.EntityFrameworkCore;
using MovieApp.Domain;

namespace MovieApp.Data;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
    {

    }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
}