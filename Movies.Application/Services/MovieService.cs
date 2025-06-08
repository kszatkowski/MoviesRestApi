using Movies.Application.Entities;
using Movies.Application.Models;
using Movies.Application.Repositories;

namespace Movies.Application.Services;

public class MovieService(IMovieRepository movieRepository) : IMovieService
{
    public async Task<IEnumerable<Movie>> GetAllAsync(MoviesOptions options, CancellationToken token = default)
    {
        return await movieRepository.GetAllAsync(options, token);
    }

    public async Task<int> GetTotalCountAsync(CancellationToken token = default)
    {
        return await movieRepository.GetTotalCountAsync(token);
    }

    public async Task<Movie?> GetAsync(Guid id, MovieOptions options, CancellationToken token = default)
    {
        return await movieRepository.GetAsync(id, options, token);
    }
}