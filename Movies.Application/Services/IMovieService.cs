using Movies.Application.Models;
using Movies.Contracts.Requests;
using Movies.Domain.Entities;

namespace Movies.Application.Services;

public interface IMovieService
{
    Task<PagedResult<Movie>> GetAllAsync(MoviesOptions options, CancellationToken token = default);
    // Task<int> GetTotalCountAsync(CancellationToken token = default);
    Task<Movie?> GetAsync(Guid id, MovieOptions options, CancellationToken token = default);
    Task<Movie> CreateAsync(UpsertMovieRequest request, CancellationToken token = default);
    Task<Movie?> UpdateAsync(Guid id, UpsertMovieRequest request, CancellationToken token = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken token = default);
}