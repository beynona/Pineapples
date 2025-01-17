namespace Alexander;

internal static class Program
{
    public static void Main()
    {
        // РЕШЕНИЕ ПЕРВОЙ ЗАДАЧИ
        Task_1();

        // РЕШЕНИЕ ВТОРОЙ ЗАДАЧИ
        Task_2();
    }

    private static void Task_1()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("Введите имя: ");
        string? firstName = Console.ReadLine();
        Console.Write("Введите Фамилию: ");
        string? lastName = Console.ReadLine();
        Console.Write("Введите возраст: ");
        int age = (int.TryParse(Console.ReadLine(), out var ageInt) ? ageInt : 0);
        Console.Write("Введите вес: ");
        double weight = (double.TryParse(Console.ReadLine(), out var weightDouble) ? weightDouble : 0);
        Console.Write("Работаете ли (да/нет): ");
        string? working = Console.ReadLine().ToLower();
        Console.WriteLine($"\nФамилия: {lastName}, Имя: {firstName}\nВозраст: {age}\nВес: {weight}\n" +
                          $"Работает: {(working == "да" || working == "нет" ? working : "не определено")}\n");
    }

    private static void Task_2()
    {
        do
        {
            Console.WriteLine("Введите два числа: ");
            if (double.TryParse(Console.ReadLine(), out var x) && double.TryParse(Console.ReadLine(), out var y))
            {
                Console.WriteLine($"\nsum = {x + y}\nmult = {x * y}\nsub = {x - y}\ndiv = {x / y}");
                break;
            }

            Console.WriteLine("Читать разучился? Числа давай, ЖИВО!!!");
        } while (true);
    }
}