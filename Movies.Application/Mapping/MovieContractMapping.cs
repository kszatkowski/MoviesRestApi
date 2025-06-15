using Movies.Application.Entities;
using Movies.Contracts.Requests;
    
namespace Movies.Application.Mapping;

public static class MovieContractMapping
{
    public static Movie MapToMovie(this UpsertMovieRequest request, IReadOnlyList<Genre> genres)
    {
        return new Movie()
        {
            Title = request.Title,
            YearOfRelease = request.YearOfRelease,
            Description = request.Description,
            Genres = genres.ToList()
        };
    }
}