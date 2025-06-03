namespace TestProjects;

static class Program
{
    public static void Main()
    {
        // ApplePractice(); // Products

        CarPractice(); // Cars
    }

    private static void CarPractice()
    {
        List<ICar> cars = new List<ICar>
        {
            new Lada(),
            new BmwSeven()
        };

        foreach (var car in cars)
        {
            car.Move(155);
        }
    }

    private static void ApplePractice()
    {
        Apple firstApple = new Apple("Red Apple", 5, 6);
        Console.WriteLine($"First apple: {firstApple}"); // Вывод имени 1 объекта
        
        Apple secondApple = new Apple("Green Apple", 6, 2);
        Console.WriteLine($"First apple: {secondApple}");   // Вывод имени 2 объекта

        Apple sumApples = firstApple + secondApple;
        Console.WriteLine($"Sum apples: {sumApples}");

        Eating<Apple> eating = new Eating<Apple>(); // Тест дженериков (обобщений)
        eating.Add(firstApple);
        Console.WriteLine($"Eating first apple: {eating}");
        eating.Add(secondApple);
        Console.WriteLine($"Eating second apple: {eating}");

    }
}