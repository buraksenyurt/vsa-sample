namespace MovieApp.Domain;

public class Genre{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Movie> Movies { get; set; }
}