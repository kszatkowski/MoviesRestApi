using Movies.Application.Entities;

namespace Movies.Application.Repositories;

public interface IGenreRepository
{
    Task<IReadOnlyList<Genre>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken token = default);
}