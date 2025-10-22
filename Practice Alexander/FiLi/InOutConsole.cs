namespace Alexander.FiLi;

internal abstract class InOutConsole
{
    private const string Separator =
        "+=========================================================================================================+";

    internal static string OutMenu()
    {
        const string menu = """
                            1. Список фильмов.
                            2. Добавить фильм.
                            3. Очистить консоль.
                            4. Выход.
                            Введите номер пункта меню: 
                            """;
        Console.Write(menu);

        do
        {
            string? select = Console.ReadLine();
            if (select is "1" or "2" or "3" or "4")
            {
                Console.WriteLine(Separator);
                return select;
            }

            Console.Write("Неверный ввод! Повторите: ");
        } while (true);
    }

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
        Console.WriteLine(Separator);

        return new Movie(name, year, genre, director, actors, description);
    }

    internal static void OutListMovie()
    {
        string[] list = WorkingWithFili.GetListMovies();
        for (int i = 0; i < list.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {list[i]}.");
        }

        Console.WriteLine(Separator);
    }

    internal static void SelectMovie()
    {
        Console.Write("Введите название из списка, для просмотра подробной информации: ");
        string? nameFile = Console.ReadLine();
        Movie.Print(WorkingWithFili.ReadJson(nameFile));
        Console.Write("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
        Console.WriteLine(Separator);
    }
}