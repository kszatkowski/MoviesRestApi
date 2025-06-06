using Movies.Application.Entities;

namespace Movies.Application.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default);
}