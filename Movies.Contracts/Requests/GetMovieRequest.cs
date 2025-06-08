namespace Movies.Contracts.Requests;

public class GetMovieRequest
{
    public required List<string> Include { get; init; } = new();
}