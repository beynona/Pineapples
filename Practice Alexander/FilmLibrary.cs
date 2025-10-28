using Alexander.FiLi;

namespace Alexander;

public static class FilmLibrary
{
    public static void StartApp()
    {
        Console.Clear();
        Console.WriteLine(TextExtension.StartMessage);
        FileManager.InitBaseLibrary();
        do
        {
            string? select = InOutConsole.OutMenu();
            switch (select)
            {
                case "1":
                    InOutConsole.OutListMovie();
                    InOutConsole.SelectMovie();
                    break;
                case "2":
                    FileManager.WriteJson(InOutConsole.AddMovie());
                    break;
                case "3":
                    Console.Clear();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("НЕВЕРНЫЙ ВВОД! Повторите...");
                    continue;
            }
        } while (true);
    }
}