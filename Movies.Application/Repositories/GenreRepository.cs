using Microsoft.EntityFrameworkCore;
using Movies.Application.Database;
using Movies.Application.Entities;

namespace Movies.Application.Repositories;

public class GenreRepository(AppDbContext appDbContext) : IGenreRepository
{
    public async Task<IReadOnlyList<Genre>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken token = default)
    {
        return await appDbContext.Genres
            .Where(x => ids.Contains(x.Id))
            .ToListAsync(token);
    }
}