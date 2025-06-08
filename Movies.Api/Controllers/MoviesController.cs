using Microsoft.AspNetCore.Mvc;
using Movies.Api.Mapping;
using Movies.Application.Services;
using Movies.Contracts.Requests;

namespace Movies.Api.Controllers;

[ApiController]
public class MoviesController(IMovieService movieService) : ControllerBase
{
    [HttpGet(ApiEndpoints.Movies.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllMoviesRequest request, CancellationToken cancellationToken)
    {
        var options = request.MapToMoviesOptions();
        var movies = await movieService.GetAllAsync(options, cancellationToken);
        var totalCount = await movieService.GetTotalCountAsync(cancellationToken);
        var response = movies.MapToResponse(options.Page, options.PageSize, totalCount);

        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Movies.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id, [FromQuery] GetMovieRequest request, CancellationToken cancellationToken)
    {
        var options = request.MapToMovieOptions();
        var movie = await movieService.GetAsync(id, options, cancellationToken);

        if (movie == null)
        {
            return NotFound();
        }

        var response = movie.MapToResponse();
        
        return Ok(response);
    }
}