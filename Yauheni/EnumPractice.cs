namespace Yauheni;

public class EnumPractice
{
    public enum Season
    {
        April,
        Spring,
        Winter
    }

    public string SelectSeason(int day, Season season)
    {
        return season switch
        {
            Season.April => "April:" + day,
            Season.Spring => "Spring:" + day,
            Season.Winter => "Winter:" + day,
            _ => "Error"
        };
    }

    public void GetConsoleKey()
    {
        ConsoleKey key = Console.ReadKey().Key;
        Console.WriteLine($"Вы нажали: {key}");
    }
}