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
        
        // ПОИСК СОВЕРШЕННЫХ ЧИСЕЛ ПРЯМЫМ ПЕРЕБОРОМ
        // PerfectNumbersSearch_1();
        
        // ПОИСК СОВЕРШЕННЫХ ЧИСЕЛ ПУТЕМ ПРОВЕРКИ МНОЖИТЕЛЯ НА ПРОСТОЕ ЧИСЛО
        PerfectNumbersSearch_2();
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
                if (i % j == 0) divisorSum += j;
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

    /*
    Для совершенных чисел существует формула - (2^(p-1))*((2^p)-1) при условии, что (2^p)-1 является простым
    числом. Простое число - натуральное число отличное от 1,которое делится без остатка только на 1 и на само себя.
    Поиск совершенных чисел в данном решении будет производиться путем проверки на простое число.
    */
    private static void PerfectNumbersSearch_2()
    {
        ulong[] perfectNumbers = new ulong[10];
        // Перебираем степени по 60ю включительно, так как на 61ой проверяемый множитель будет порядка максимального
        // значения типа ulong. Максимально возможное число для определения при данном типе - 8-е число (на степени 31).
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
                    break;
                }
            }
        }
        Console.WriteLine($"{Message}\nНайдены следующие совершенные числа: ");
        for (int i = 0; perfectNumbers[i] != 0 && i < perfectNumbers.Length; i++)
            Console.WriteLine($"#{i + 1}. {perfectNumbers[i]}");

        return;

        // возведение в степень по основанию 2
        ulong Power(int pow)
        {
            ulong result = 1;
            for (int i = 0; i < pow; i++)
                result *= 2;
            return result;
        }
    }
}