using System.ComponentModel.DataAnnotations;

namespace MovieApp.Domain;

public class Movie{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal TotalRevenue { get; set; }
    public DateTime ReleaseDate { get; set; }
    public double ImdbPoint { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}