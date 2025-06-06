using Microsoft.EntityFrameworkCore;
using Movies.Application.Database;
using Movies.Application.Entities;

namespace Movies.Application.Repositories;

public class MovieRepository(AppDbContext appDbContext) : IMovieRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default)
    {
        return await _appDbContext.Movies.ToListAsync(token);
    }
}