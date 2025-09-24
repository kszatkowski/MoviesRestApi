using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Domain.Repositories;
using Movies.Infrastructure.Database;

namespace Movies.Infrastructure.Repositories;

public class GenreRepository(AppDbContext appDbContext) : IGenreRepository
{
    public async Task<IReadOnlyList<Genre>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken token = default)
    {
        return await appDbContext.Genres
            .Where(x => ids.Contains(x.Id))
            .ToListAsync(token);
    }
}