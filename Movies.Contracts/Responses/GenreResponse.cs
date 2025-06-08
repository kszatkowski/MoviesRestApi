namespace Movies.Contracts.Responses;

public class GenreResponse
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
}