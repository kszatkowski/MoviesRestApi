namespace Movies.Application.Models;

public enum MovieIncludeOption
{
    Genres
}

public class MovieOptions
{
    public required IEnumerable<MovieIncludeOption> Include { get; set; }
    
    public static IEnumerable<MovieIncludeOption> GetIncludeOptions(List<string> include)
    {
        foreach (var value in include)
        {
            if (Enum.TryParse<MovieIncludeOption>(value, true, out var option))
            {
                yield return option;
            }
        }        
    }
}