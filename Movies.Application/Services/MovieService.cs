using Movies.Application.Entities;
using Movies.Application.Repositories;

namespace Movies.Application.Services;

public class MovieService(IMovieRepository movieRepository) : IMovieService
{
    private readonly IMovieRepository _movieRepository = movieRepository;

    public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default)
    {
        return await this._movieRepository.GetAllAsync(token);
    }
}