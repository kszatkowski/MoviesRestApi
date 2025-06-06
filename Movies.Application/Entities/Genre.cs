using System.ComponentModel.DataAnnotations;

namespace Movies.Application.Entities;

public class Genre
{
    [Key]
    public Guid Id { get; set; }
    public required string Title { get; set; }
    
    public ICollection<Movie> Movies { get; set; }
}