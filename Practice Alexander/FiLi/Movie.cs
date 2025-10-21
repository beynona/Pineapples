namespace Alexander.FiLi;

internal class Movie(string? name, string? year, string? genre, string? director, string? actors, string? description)
{
    public string? Name { get; set; } = name;
    public string? Year { get; set; } = year;
    public string? Genre { get; set; } = genre;
    public string? Director { get; set; } = director;
    public string? Actors { get; set; } = actors;
    public string? Description { get; set; } = description;

    internal static void Print(Movie? movie)
    {
        if (movie != null)
            Console.WriteLine
            (
                $"""
                 +=========================================================================================================+
                 1. НАЗВАНИЕ: {movie.Name}.
                 +---------------------------------------------------------------------------------------------------------+
                 2. ГОД: {movie.Year}.
                 +---------------------------------------------------------------------------------------------------------+
                 3. ЖАНР: {movie.Genre}.
                 +---------------------------------------------------------------------------------------------------------+
                 4. РЕЖИССЕР: {movie.Director}.
                 +---------------------------------------------------------------------------------------------------------+
                 5. АКТЕРЫ:
                 {movie.Actors}.
                 +---------------------------------------------------------------------------------------------------------+
                 6. ОПИСАНИЕ:
                 {movie.Description}.
                 +=========================================================================================================+
                 """
            );
    }
}