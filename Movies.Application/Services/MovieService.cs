using FluentValidation;
using Movies.Application.Database;
using Movies.Application.Entities;
using Movies.Application.Mapping;
using Movies.Application.Models;
using Movies.Application.Repositories;
using Movies.Contracts.Requests;

namespace Movies.Application.Services;

public class MovieService(
    IMovieRepository movieRepository,
    IGenreRepository genreRepository,
    IValidator<UpsertMovieRequest> movieValidator,
    IUnitOfWork unitOfWork
    ) : IMovieService
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

    public async Task<Movie> CreateAsync(UpsertMovieRequest request, CancellationToken token = default)
    {
        await movieValidator.ValidateAndThrowAsync(request, token);
        var selectedGenres = await genreRepository.GetByIdsAsync(request.GenreIds, token);
        var movie = request.MapToMovie(selectedGenres);

        await unitOfWork.BeginTransactionAsync();

        try
        {
            await movieRepository.CreateAsync(movie, token);
            await unitOfWork.CommitAsync();

            return movie;
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }
}