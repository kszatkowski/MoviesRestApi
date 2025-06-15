using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Movies.Application.Constants;
using Movies.Application.Database;
using Movies.Contracts.Requests;

namespace Movies.Application.Validators;

public class UpsertMovieRequestValidator : AbstractValidator<UpsertMovieRequest>
{
    private readonly AppDbContext _appDbContext;

    public UpsertMovieRequestValidator(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;

        RuleFor(movie => movie.Title)
            .NotEmpty()
            .MaximumLength(MovieConstraints.TitleMaxLength);

        RuleFor(movie => movie.YearOfRelease)
            .NotEmpty();
        
        RuleFor(movie => movie.Description)
            .MaximumLength(MovieConstraints.DescriptionMaxLength);

        RuleFor(movie => movie.GenreIds)
            .NotEmpty()
            .WithMessage("At least one genre is required.")
            .MustAsync(AllGenresExist)
            .WithMessage("Some genres do not exist.");;
    }

    private async Task<bool> AllGenresExist(List<Guid> genreIds, CancellationToken token)
    {
        var existingIds = await _appDbContext.Genres
            .Where(g => genreIds.Contains(g.Id))
            .Select(g => g.Id)
            .ToListAsync(token);

        return !genreIds.Except(existingIds).Any();
    }
}