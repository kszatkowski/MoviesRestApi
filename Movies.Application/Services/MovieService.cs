using FluentValidation;
using Movies.Application.Mapping;
using Movies.Application.Models;
using Movies.Application.Specifications;
using Movies.Contracts.Requests;
using Movies.Domain.Entities;
using Movies.Domain.Repositories;
using Movies.Infrastructure.Database;

namespace Movies.Application.Services;

public class MovieService(
    IMovieRepository movieRepository,
    IGenreRepository genreRepository,
    IValidator<UpsertMovieRequest> movieValidator,
    IUnitOfWork unitOfWork
    ) : IMovieService
{
    public async Task<PagedResult<Movie>> GetAllAsync(MoviesOptions options, CancellationToken token = default)
    {
        var spec = new MoviesByOptionsSpecifications(options);
        var result = await movieRepository.GetBySpecificationAsync(spec, options.Page, options.PageSize, token);

        return new PagedResult<Movie>(result.movies, result.totalCount, options.Page, options.PageSize);
    }

    // public async Task<int> GetTotalCountAsync(CancellationToken token = default)
    // {
    //     return await movieRepository.GetTotalCountAsync(token);
    // }

    public async Task<Movie?> GetAsync(Guid id, MovieOptions options, CancellationToken token = default)
    {
        var includes = MovieIncludeMapping.GetIncludes(options.Include);

        return await movieRepository.GetAsync(id, includes, token);
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

    public async Task<Movie?> UpdateAsync(Guid id, UpsertMovieRequest request, CancellationToken token = default)
    {
        await movieValidator.ValidateAndThrowAsync(request, token);
        var movieIncludes = MovieIncludeMapping.GetIncludes([MovieIncludeOption.Genres]);
        var movie = await movieRepository.GetAsync(id, movieIncludes, token);
    
        if (movie == null)
        {
            return null;
        }
    
        var selectedGenres = await genreRepository.GetByIdsAsync(request.GenreIds, token);
    
        await unitOfWork.BeginTransactionAsync();
    
        try
        {
            ApplyUpdate(request, movie, selectedGenres);
            await unitOfWork.CommitAsync();
    
            return movie;
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
    {
        var movie = await movieRepository.GetAsync(id, token: token);
    
        if (movie == null)
        {
            return false;
        }
        
        movieRepository.Delete(movie);
        await unitOfWork.SaveChangesAsync();
    
        return true;
    }
    
    private void ApplyUpdate(UpsertMovieRequest request, Movie movie, IReadOnlyList<Genre> genres)
    {
        movie.Title = request.Title;
        movie.Description = request.Description;
        movie.YearOfRelease = request.YearOfRelease;
    
        movie.Genres.Clear();
        foreach (var genre in genres)
        {
            movie.Genres.Add(genre);
        }
    }
}