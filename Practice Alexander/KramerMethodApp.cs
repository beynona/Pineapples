using Alexander.KramerMethodTools;

namespace Alexander;

public static class KramerMethodApp
{
    public static void StartApp()
    {
        Console.WriteLine(TextHelper.StartMessage);
        do
        {
            Console.Write("\n" + TextHelper.QuestionNumberEquations);
            string? input = Console.ReadLine()?.ToLower();
            switch (input)
            {
                case "2" or "3":
                    int numberEquations = Convert.ToInt32(input);
                    double[][] matrix = DataManager.DataGeneration(ref numberEquations);
                    double[][] result = DataManager.Calculation(ref matrix, ref numberEquations);
                    string message = TextHelper.PreparingOutput(ref matrix, ref result, ref numberEquations);
                    LogManager.WriteLog(ref message, TextHelper.Path);
                    Console.WriteLine($"\n{TextHelper.Separator}\n{message}");
                    break;
                case "doc":
                    Console.WriteLine("\n" + TextHelper.StartMessage);
                    break;
                case "last":
                    LogManager.ReadLastLog(TextHelper.Path, TextHelper.Separator);
                    break;
                case "read":
                    LogManager.ReadLogs(TextHelper.Path, TextHelper.Separator);
                    break;
                case "clear":
                    LogManager.ClearLogs(TextHelper.Path);
                    break;
                case "exit":
                    Console.WriteLine("\n" + TextHelper.EndMessage);
                    return;
                default:
                    Console.WriteLine(TextHelper.InvalidInputMessage);
                    continue;
            }
        } while (true);
    }
}