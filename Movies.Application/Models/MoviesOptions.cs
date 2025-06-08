namespace Movies.Application.Models;

public class MoviesOptions : MovieOptions
{
    public string? Title { get; set; }
    public int? YearOfRelease { get; set; }
    public int Page { get; init; }
    public int PageSize { get; init; }
}