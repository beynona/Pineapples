namespace Alexander.FiLi;

internal abstract class InOutConsole
{
    internal static Movie AddMovie()
    {
        Console.Write("Введите название: ");
        string? name = Console.ReadLine();
        Console.Write("Введите год релиза: ");
        string? year = Console.ReadLine();
        Console.Write("Введите жанр(ы): ");
        string? genre = Console.ReadLine();
        Console.Write("Введите режиссера: ");
        string? director = Console.ReadLine();
        Console.Write("Введите актеров: ");
        string? actors = Console.ReadLine();
        Console.Write("Введите описание: ");
        string? description = Console.ReadLine();

        return new Movie(name, year, genre, director, actors, description);
    }

    internal static void OutListMovie()
    {
        foreach (string movie in WorkingWithFili.GetListMovies())
        {
            Console.WriteLine(movie);
        }
    }
}