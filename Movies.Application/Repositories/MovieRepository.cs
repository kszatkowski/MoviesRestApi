using Microsoft.EntityFrameworkCore;
using Movies.Application.Database;
using Movies.Application.Entities;
using Movies.Application.Models;

namespace Movies.Application.Repositories;

public class MovieRepository(AppDbContext appDbContext) : IMovieRepository
{
    public async Task<IEnumerable<Movie>> GetAllAsync(MoviesOptions options, CancellationToken token = default)
    {
        IQueryable<Movie> query = appDbContext.Movies;
        
        if (options.Include.Contains(MovieIncludeOption.Genres))
        {
            query = query.Include(m => m.Genres);
        }
        
        query = query
            .Skip((options.Page - 1) * options.PageSize)
            .Take(options.PageSize);

        return await query.ToListAsync(token);
    }

    public async Task<int> GetTotalCountAsync(CancellationToken token = default)
    {
        return await appDbContext.Movies.CountAsync(token);
    }

    public async Task<Movie?> GetAsync(Guid id, MovieOptions options, CancellationToken token = default)
    {
        IQueryable<Movie> query = appDbContext.Movies;

        if (options.Include.Contains(MovieIncludeOption.Genres))
        {
            query = query.Include(m => m.Genres);
        }

        return await query.FirstOrDefaultAsync(movie => movie.Id == id, token);
    }
}