
namespace EducationVS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO - комментарии через 1 пробел оставляются.
            const string Work0 = " Не определился ";
            Console.Write("Введите Имя: "); // Отображение в консоли.
            string? firstname = Console.ReadLine(); // Ввод с консоли.
                Console.Write("Введите Фамилию: ");
                string? name = Console.ReadLine();
                    Console.Write("Введите возраст: ");           
                    int age; // Парсинг в целые числа
                    while (!int.TryParse(Console.ReadLine(), out age)) // ТруПарсинг возраста.
                    Console.Write("Неверный ввод! \nВведите возраст: ");
                    Console.WriteLine("Ваш возраст = {0}", age);
                Console.Write("Введите свой вес: ");
                double weight;
                while (!double.TryParse(Console.ReadLine(), out weight)) // ТруПарсинг веса.
                Console.Write("Неверный ввод! \nВведите свой вес: ");
                Console.WriteLine("Ваш вес = {0}", weight);
            Console.Write("Работате?: (Да/Нет) ");
            string work = Console.ReadLine().ToUpper();
            bool workA = (work == "ДА" || work == "НЕТ");    
            Console.WriteLine($"\nВаше Имя: {firstname} \nВаша Фамилия: {name} \nВаш Возраст: {age}"); 
            Console.WriteLine($"Ваш Вес: {weight} \nРаботаете? {(workA ? work : Work0)}"); // Вывод на консоль.
            Console.ReadKey();            
        }
    }
}
