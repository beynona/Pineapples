namespace Alexander.FiLi;

internal static class InOutConsole
{
    internal static string? OutMenu()
    {
        Console.Write(TextExtension.Menu);
        string? select = Console.ReadLine();
        Console.WriteLine(TextExtension.Separator);
        return select;
    }

    internal static Movie AddMovie()
    {
        Movie movie = new Movie();
        Console.Write("Введите название: ");
        movie.Name = Console.ReadLine();
        Console.Write("Введите год релиза: ");
        movie.Year = Console.ReadLine();
        Console.Write("Введите жанр(ы): ");
        movie.Genre = Console.ReadLine();
        Console.Write("Введите режиссера: ");
        movie.Director = Console.ReadLine();
        Console.Write("Введите актеров: ");
        movie.Actors = Console.ReadLine();
        Console.Write("Введите описание: ");
        movie.Description = Console.ReadLine();
        Console.WriteLine(TextExtension.Separator);

        return movie;
    }

    internal static void OutListMovie()
    {
        string[] list = FileManager.GetListMovies();
        for (int i = 0; i < list.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {list[i]}.");
        }

        Console.WriteLine(TextExtension.Separator);
    }

    internal static void SelectMovie()
    {
        Console.Write("Введите название из списка, для просмотра подробной информации: ");
        string? nameFile = Console.ReadLine();
        Movie.Print(FileManager.ReadJson(nameFile));
        Console.Write("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
        Console.WriteLine(TextExtension.Separator);
    }
}