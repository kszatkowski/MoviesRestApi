namespace Movies.Domain.Entities;

public class Movie
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required int YearOfRelease { get; set; }
    public string? Description { get; set; }

    public ICollection<Genre> Genres { get; set; }
}