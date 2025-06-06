using Movies.Application.Entities;

namespace Movies.Application.Services;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default);
}