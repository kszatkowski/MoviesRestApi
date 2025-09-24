using System.Linq.Expressions;
using Movies.Domain.Entities;
using Movies.Domain.Specifications;

namespace Movies.Domain.Repositories;

public interface IMovieRepository
{
    // Task<IEnumerable<Movie>> GetAllAsync(MoviesOptions options, CancellationToken token = default);
    Task<(IReadOnlyList<Movie> movies, int totalCount)> GetBySpecificationAsync(ISpecification<Movie> spec, int pageNumber, int pageSize, CancellationToken token = default);
    // Task<int> GetTotalCountAsync(CancellationToken token = default);
    Task<Movie?> GetAsync(Guid id, IEnumerable<Expression<Func<Movie, object>>>? includes = null!, CancellationToken token = default);
    Task CreateAsync(Movie movie, CancellationToken token = default);
    void Delete(Movie movie);
}