using Movies.Application.Entities;
using Movies.Application.Models;

namespace Movies.Application.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync(MoviesOptions options, CancellationToken token = default);
    Task<int> GetTotalCountAsync(CancellationToken token = default);
    Task<Movie?> GetAsync(Guid id, MovieOptions? options = null, CancellationToken token = default);
    Task CreateAsync(Movie movie, CancellationToken token = default);
    void Delete(Movie movie);
}