using Movies.Application.Entities;
using Movies.Application.Models;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.Api.Mapping;

public static class ContractMapping
{
    public static MovieResponse MapToResponse(this Movie movie)
    {
        return new MovieResponse()
        {
            Id = movie.Id,
            Title = movie.Title,
            YearOfRelease = movie.YearOfRelease,
            Genres = movie.Genres?.Select(g => new GenreResponse()
            {
                Id = g.Id,
                Title = g.Title
            }),
        };
    }
    
    public static MovieOptions MapToMovieOptions(this GetMovieRequest request)
    {
        return new MovieOptions()
        {
            Include = MovieOptions.GetIncludeOptions(request.Include)
        };
    }

    public static MoviesOptions MapToMoviesOptions(this GetAllMoviesRequest request)
    {
        return new MoviesOptions()
        {
            Include = MovieOptions.GetIncludeOptions(request.Include),
            Page = request.Page,
            PageSize = request.PageSize,
        };
    }

    public static MoviesResponse MapToResponse(this IEnumerable<Movie> movies, int page, int pageSize, int total)
    {
        return new MoviesResponse()
        {
            Items = movies.Select(MapToResponse),
            Page = page,
            PageSize = pageSize,
            Total = total
        };
    }
}