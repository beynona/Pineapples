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
        Console.Write("Введите название: ");
        string name = Console.ReadLine();
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
        Console.WriteLine(TextExtension.Separator);

        return new Movie(name, year, genre, director, actors, description);
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