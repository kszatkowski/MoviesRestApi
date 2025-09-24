using System.Linq.Expressions;
using Movies.Application.Models;
using Movies.Domain.Entities;
using Movies.Domain.Specifications;

namespace Movies.Application.Specifications;

public class MovieByOptionsSpecification : ISpecification<Movie>
{
    public Expression<Func<Movie, bool>>? Criteria { get; }
    public List<Expression<Func<Movie, object>>> Includes { get; } = new();

    public MovieByOptionsSpecification(MovieOptions options)
    {
        if (options.Include.Contains(MovieIncludeOption.Genres))
        {
            Includes.Add(m => m.Genres);
        }
    }
}