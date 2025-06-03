
namespace Maxim
{
    public static class MainProgram
    {
        private const string DefaultWorkStatus = "Не определился";

        static void Main()
        {
            // 1 Задание
            Task_1();
        }

        private static void Task_1()
        {
            Console.Write("Введите Имя: "); // Отображение в консоли.
            string? firstname = Console.ReadLine(); // Ввод с консоли.
            Console.Write("Введите Фамилию: ");
            string? name = Console.ReadLine();
            Console.Write("Введите возраст: ");

            int age; // Парсинг в целые числа
            while (!int.TryParse(Console.ReadLine(), out age)) // ТруПарсинг возраста.
                Console.Write("Неверный формат ввода! Введите свой возраст: ");
            Console.Write("Введите свой вес: ");

            double weight;
            while (!double.TryParse(Console.ReadLine(), out weight)) // ТруПарсинг веса.
                Console.Write("Неверный ввода! Введите свой вес: ");

            Console.Write("Работате?: (Да/Нет) ");
            string? work = Console.ReadLine()?.ToUpper();
            bool workA = (work == "ДА" || work == "НЕТ");
            Console.Write($"\nВаше Имя: {firstname} \nВаша Фамилия: {name} \nВаш Возраст: {age}\n" +
                          $"Ваш Вес: {weight} \nТрудоустройство: {(workA ? work : DefaultWorkStatus)}"); // Вывод на консоль.
            Console.ReadKey();
        }
    }
}
