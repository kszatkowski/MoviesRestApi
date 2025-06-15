namespace Movies.Contracts.Requests;

public class UpsertMovieRequest
{
    public required string Title { get; init; }
    public required int YearOfRelease { get; init; }
    public string? Description { get; init; }
    public List<Guid> GenreIds { get; init; } = new();
}