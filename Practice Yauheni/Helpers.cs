namespace Yauheni;

public static class Helpers
{
    // Хелпер для вывода массива на консоль
    public static void ConsoleHelper(int[] testArray, string message)
    {
        Console.Write(message);
        foreach (var array in testArray)
        {
            Console.Write(array + " "); // 2 4 99 5
        }
        Console.WriteLine();
    }
}