using System.Linq.Expressions;
using Movies.Application.Models;
using Movies.Domain.Entities;
using Movies.Domain.Specifications;

namespace Movies.Application.Specifications;

public class MoviesByOptionsSpecifications : ISpecification<Movie>
{
    public Expression<Func<Movie, bool>>? Criteria { get; }
    public List<Expression<Func<Movie, object>>> Includes { get; } = new();

    public MoviesByOptionsSpecifications(MoviesOptions options)
    {
        Criteria = movie =>
            (string.IsNullOrEmpty(options.Title) || movie.Title.Contains(options.Title)) &&
            (!options.YearOfRelease.HasValue || movie.YearOfRelease == options.YearOfRelease.Value);

        if (options.Include.Contains(MovieIncludeOption.Genres))
        {
            Includes.Add(m => m.Genres);
        }
    }
}
