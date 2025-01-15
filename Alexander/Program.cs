namespace Alexander;

internal static class Program   
{
    public static void Main()
    {
        //РЕШЕНИЕ ПЕРВОЙ ЗАДАЧИ
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
        string? working = Console.ReadLine();
        bool work = (working == "да") | (working == "нет");
        Console.WriteLine($"\nФамилия: {lastName}, Имя: {firstName}\nВозраст: {age}\nВес: {weight}\n" +
                          $"Работает: {(work ? working : "не определено")}\n");

        //РЕШЕНИЕ ВТОРОЙ ЗАДАЧИ
        do
        {
            Console.WriteLine("Введите два числа: ");
            if (double.TryParse(Console.ReadLine(), out var x) & double.TryParse(Console.ReadLine(), out var y))
            {
                Console.WriteLine($"\nsum = {x + y}\nmult = {x * y}\nsub = {x - y}\ndiv = {x / y}");
                break;
            }
            Console.WriteLine("Читать разучился? Числа давай, ЖИВО!!!");
        } while (true);
    }
}