using System.Linq.Expressions;
using Movies.Application.Models;
using Movies.Domain.Entities;

namespace Movies.Application.Mapping;

public static class MovieIncludeMapping
{
    private static readonly Dictionary<MovieIncludeOption, Expression<Func<Movie, object>>> _map
        = new()
        {
            { MovieIncludeOption.Genres, m => m.Genres },
        };
    
    public static IEnumerable<Expression<Func<Movie, object>>>? GetIncludes(IEnumerable<MovieIncludeOption> options)
    {
        foreach (var opt in options)
        {
            if (_map.TryGetValue(opt, out var includeExpr))
                yield return includeExpr;
        }
    }
}