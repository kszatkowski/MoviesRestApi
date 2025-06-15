using Movies.Application.Entities;
using Movies.Application.Models;
using Movies.Contracts.Requests;

namespace Movies.Application.Services;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllAsync(MoviesOptions options, CancellationToken token = default);
    Task<int> GetTotalCountAsync(CancellationToken token = default);
    Task<Movie?> GetAsync(Guid id, MovieOptions options, CancellationToken token = default);
    Task<Movie> CreateAsync(UpsertMovieRequest request, CancellationToken token = default);
}