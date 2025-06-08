namespace Movies.Contracts.Requests;

public class GetAllMoviesRequest : PageRequest
{
    public required List<string> Include { get; init; } = new();
}