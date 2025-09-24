using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Domain.Repositories;
using Movies.Domain.Specifications;
using Movies.Infrastructure.Database;

namespace Movies.Infrastructure.Repositories;

public class MovieRepository(AppDbContext appDbContext) : IMovieRepository
{
    public async Task<(IReadOnlyList<Movie> movies, int totalCount)> GetBySpecificationAsync(ISpecification<Movie> spec, int pageNumber, int pageSize, CancellationToken token = default)
    {
        var query = appDbContext.Movies.AsQueryable();

        if (spec.Criteria is not null)
        {
            query = query.Where(spec.Criteria);
        }
        
        foreach (var includeExpression in spec.Includes)
        {
            query = query.Include(includeExpression);
        }
        
        var totalCount = await query.CountAsync(token);
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(token);

        return (items, totalCount);
    }

    // public async Task<IEnumerable<Movie>> GetAllAsync(MoviesOptions options, CancellationToken token = default)
    // {
    //     IQueryable<Movie> query = appDbContext.Movies;
    //     
    //     if (options.Include.Contains(MovieIncludeOption.Genres))
    //     {
    //         query = query.Include(m => m.Genres);
    //     }
    //     
    //     query = query
    //         .Skip((options.Page - 1) * options.PageSize)
    //         .Take(options.PageSize);
    //
    //     return await query.ToListAsync(token);
    // }

    // public async Task<int> GetTotalCountAsync(CancellationToken token = default)
    // {
    //     return await appDbContext.Movies.CountAsync(token);
    // }

    public async Task<Movie?> GetAsync(Guid id, IEnumerable<Expression<Func<Movie, object>>>? includes = null, CancellationToken token = default)
    {
        IQueryable<Movie> query = appDbContext.Movies;
        includes ??= Enumerable.Empty<Expression<Func<Movie, object>>>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        
        return await query.FirstOrDefaultAsync(movie => movie.Id == id, token);
    }

    public async Task CreateAsync(Movie movie, CancellationToken token = default)
    {
        await appDbContext.Movies.AddAsync(movie, token);
    }
    
    public void Delete(Movie movie)
    {
        appDbContext.Movies.Remove(movie);
    }
}