using System.ComponentModel.DataAnnotations;

namespace Movies.Application.Entities;

public class Movie
{
    [Key]
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required int YearOfRelease { get; set; }
    public string? Description { get; set; }
}