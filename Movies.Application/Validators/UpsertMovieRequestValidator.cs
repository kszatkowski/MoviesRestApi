using FluentValidation;
using Movies.Contracts.Requests;
using Movies.Domain.Constants;
using Movies.Domain.Repositories;

namespace Movies.Application.Validators;

public class UpsertMovieRequestValidator : AbstractValidator<UpsertMovieRequest>
{
    private readonly IGenreRepository _genreRepository;

    public UpsertMovieRequestValidator(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
        
        RuleFor(movie => movie.Title)
            .NotEmpty()
            .MaximumLength(MovieConstraints.TitleMaxLength);
    
        RuleFor(movie => movie.YearOfRelease)
            .NotEmpty();
        
        RuleFor(movie => movie.Description)
            .MaximumLength(MovieConstraints.DescriptionMaxLength);
    
        // RuleFor(movie => movie.GenreIds)
        //     .NotEmpty()
        //     .WithMessage("At least one genre is required.")
        //     .MustAsync(AllGenresExist)
        //     .WithMessage("Some genres do not exist.");;
    }
    
    // private async Task<bool> AllGenresExist(List<Guid> genreIds, CancellationToken token)
    // {
    //     var existingIds = await _appDbContext.Genres
    //         .Where(g => genreIds.Contains(g.Id))
    //         .Select(g => g.Id)
    //         .ToListAsync(token);
    //
    //     return !genreIds.Except(existingIds).Any();
    // }
}