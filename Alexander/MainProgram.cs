namespace Alexander;

internal static class Program
{
    private const ulong LimitValue = ulong.MaxValue;
    
    public static void Main()
    {
        // РЕШЕНИЕ ПЕРВОЙ ЗАДАЧИ
        // Task_1();

        // РЕШЕНИЕ ВТОРОЙ ЗАДАЧИ
        // Task_2();
        
        // ПОИСК СОВЕРШЕННЫХ ЧИСЕЛ
        PerfectNumbersSearch_1();
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
    
    private static void PerfectNumbersSearch_1()
    {
        ulong[] perfectNumbers = new ulong[10];
        // по скольку до сих пор не найдено ни одного нечетного совершенного числа в доступном нам диапазоне,
        // выбираем по порядку четные числа до максимального значения типа ulong
        for (ulong i = 0; i <= LimitValue; i += 2)
        {
            if (i <= 2) continue;
            // 1 и 2 делители любого четного числа, поиск делителей начинаем с 3
            ulong divisorSum = 3;
            // максимальный собственный делитель не может быть больше половины делимого
            for (ulong j = 3; j <= i / 2; j++)
            {
                if (i % j == 0) divisorSum += (ulong)j;
                // если сумма делителей больше делимого - дальнейший поиск не имеет смысла
                if (divisorSum > i) break;
            }
            if (divisorSum != i) continue;
            // при инициализации элементы числового массива заполняются 0, ищем первый "пустой" и присваиваем ему
            // значение найденного совершенного числа
            for (int index = 0; perfectNumbers.Length > index; index++)
            {
                if (perfectNumbers[index] != 0) continue;
                perfectNumbers[index] = i;
                Console.WriteLine(perfectNumbers[index]);
                break;
            }
        }
    }

    private static void PerfectNumbersSearch_2()
    {
        
    }
}