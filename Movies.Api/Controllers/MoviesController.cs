using Microsoft.AspNetCore.Mvc;
using Movies.Application.Services;

namespace Movies.Api.Controllers;

[ApiController]
public class MoviesController(IMovieService movieService) : ControllerBase
{
    [HttpGet(ApiEndpoints.Movies.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var movies = await movieService.GetAllAsync();
        return Ok(movies);
    }
}