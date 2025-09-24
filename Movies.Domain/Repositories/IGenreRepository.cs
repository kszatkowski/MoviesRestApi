using Movies.Domain.Entities;

namespace Movies.Domain.Repositories;

public interface IGenreRepository
{
    Task<IReadOnlyList<Genre>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken token = default);
}