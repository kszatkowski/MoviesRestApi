namespace Movies.Domain.Entities;

public class Genre
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    
    public ICollection<Movie> Movies { get; set; }
}