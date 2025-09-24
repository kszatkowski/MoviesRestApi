using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Services;

namespace Movies.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMovieService, MovieService>();
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>();

        return services;
    }
}