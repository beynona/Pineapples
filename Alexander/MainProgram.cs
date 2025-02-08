namespace Alexander;

internal static class Program
{
    private const ulong LimitValue = ulong.MaxValue;
    private const string Message = "\nCовершенные числа - это натуральные числа,\nсумма собственных делителей которых" +
                                   " равна самому числу.\nФормула: n = (2^(p-1))*((2^p)-1)";
    
    public static void Main()
    {
        // РЕШЕНИЕ ПЕРВОЙ ЗАДАЧИ
        // Task_1();

        // РЕШЕНИЕ ВТОРОЙ ЗАДАЧИ
        // Task_2();
        
        // ПОИСК СОВЕРШЕННЫХ ЧИСЕЛ ПУТЕМ ПРОВЕРКИ МНОЖИТЕЛЯ НА ПРОСТОЕ ЧИСЛО
        // PerfectNumbersSearch();
        
        KramerMethodApp.StartApp();
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

    /*
    Для совершенных чисел существует формула - (2^(p-1))*((2^p)-1) при условии, что (2^p)-1 является простым
    числом. Простое число - натуральное число отличное от 1,которое делится без остатка только на 1 и на само себя.
    Поиск совершенных чисел в данном решении будет производиться путем проверки на простое число.
    */
    private static void PerfectNumbersSearch()
    {
        ulong[] perfectNumbers = new ulong[10];
        // Перебираем степени по 60ю включительно, так как на 61ой проверяемый множитель будет порядка максимального
        // значения типа ulong. Максимально возможное число для определения при данном типе - 8-е число (на степени 31).
        Console.WriteLine($"\nНайдены следующие совершенные числа: ");
        for (int n = 2; n < 61; n++)
        {
            ulong checkValue = Power(n)-1;
            ulong limitValue = (checkValue / 2) + 1;
            for (ulong divisor = 2; divisor <= limitValue; divisor++)
            {
                if (checkValue % divisor == 0) break;
                if (divisor != limitValue) continue;
                for (int index = 0; perfectNumbers.Length > index; index++)
                {
                    if (perfectNumbers[index] != 0) continue;
                    perfectNumbers[index] = checkValue * Power(n - 1);
                    Console.WriteLine($"#{index + 1}. {perfectNumbers[index]}");
                    break;
                }
            }
        }
        Console.Write("\nНажмите Enter чтобы выйти => ");
        Console.ReadKey();

        return;

        // возведение в степень по основанию 2
        static ulong Power(int pow)
        {
            ulong result = 1;
            for (int i = 0; i < pow; i++) result *= 2;
            return result;
        }
    }
}