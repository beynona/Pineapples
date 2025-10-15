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

        Movie endersGame = new Movie();

        Console.WriteLine
        (
            $"""
             1. Название: {endersGame.Name}.
             2. Год: {endersGame.YearRelease}.
             3. Жанр: {endersGame.Genre}.
             4. Режиссер: {endersGame.Director}.
             5. Актеры: {endersGame.Actors}.
             6. Описание:
             {endersGame.Description}.
             """
        );
    }
}