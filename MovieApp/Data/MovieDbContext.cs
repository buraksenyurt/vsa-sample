using Microsoft.EntityFrameworkCore;
using MovieApp.Domain;

namespace MovieApp.Data;

public partial class MovieDbContext
    : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Genre_pkey");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Movie_pkey");
        });
        modelBuilder.UseSerialColumns();
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
}