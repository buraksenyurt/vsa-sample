using System.ComponentModel.DataAnnotations;

namespace MovieApp.Domain;

public class Genre{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Movie> Movies { get; set; }
}