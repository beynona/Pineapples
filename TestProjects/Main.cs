namespace TestProjects;

static class Program
{
    public static void Main()
    {
        ApplePractice(); // Products
    }

    private static void ApplePractice()
    {
        Apple firstApple = new Apple("Red Apple", 5, 6);
        Console.WriteLine($"First apple: {firstApple}"); // Вывод имени 1 объекта
        
        Apple secondApple = new Apple("Green Apple", 6, 2);
        Console.WriteLine($"First apple: {secondApple}");   // Вывод имени 2 объекта

        Apple sumApples = firstApple + secondApple;
        Console.WriteLine($"Sum apples: {sumApples}"); 
    }
}