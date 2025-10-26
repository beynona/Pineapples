namespace Alexander.FiLi;

internal class Movie
{
    internal Movie()
    {
    }

    public Movie(string? name, string? year, string? genre, string? director, string? actors, string? description)
    {
        Name = name;
        Year = year;
        Genre = genre;
        Director = director;
        Actors = actors;
        Description = description;
    }

    public string? Name { get; set; }
    public string? Year { get; set; }
    public string? Genre { get; set; }
    public string? Director { get; set; }
    public string? Actors { get; set; }
    public string? Description { get; set; }

    internal static void Print(Movie? movie)
    {
        Console.WriteLine(TextExtension.GetMovieInfo(movie));
    }
}