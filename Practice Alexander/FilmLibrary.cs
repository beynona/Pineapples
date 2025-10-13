using Alexander.FiLi;

namespace Alexander;

internal abstract class FilmLibrary
{
    private const string StartMessage = """
                                        +=============================================================================+
                                        ||                            _____ ___  _    ___                            ||
                                        ||                           |  ___|_ _/| |  |_ _/                           ||
                                        ||                           | |_   | | | |   | |                            ||
                                        ||                           |  _|  | | | |__ | |                            ||
                                        ||                           |_|   |___\|____|___\                           ||
                                        ||                                                                           ||
                                        ||                   Вас приветствует FiLi (Film Library)!                   ||
                                        ||       Приложение, своего рода библиотека, которую Вы создаете сами.       ||
                                        ||                                                                           ||
                                        +=============================================================================+
                                        """;
    internal static void StartApp()
    {
        Console.Clear();
        Console.WriteLine(StartMessage);
        Console.ReadKey();

        Movie TopGun = new Movie();
        TopGun.Name = "TopGun";
    }
}