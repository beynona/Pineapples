using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// TODO - убрать неиспользуемые библиотеки
namespace EducationVS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO - комментарии через 1 пробел оставляются
            Console.Write("Введите Имя: "); // Отображение в консоли
            string firstname = Console.ReadLine();                     // Ввод с консоли
            Console.Write("Введите Фамилию: ");
            string name = Console.ReadLine();
            Console.Write("Введите возраст: ");
            //TODO - нет проверки что введено. При вводе буквы будет ошибка
            int age = int.Parse(Console.ReadLine());                  //Парсинг в целые числа
            Console.Write("Введите свой вес: ");
            double weight = double.Parse(Console.ReadLine());          //Парсинг в дробные числа
            Console.Write("Работате? (Да/Нет) ");
            string work = Console.ReadLine();
            bool workA = (work == "да" || work == "Нет");
            // TODO - Лишняя переменная. Её либо оформить константой, либо перенести значение
            const string Work0 = " Не определился ";
            //TODO - Слишком длинная строка. Нужны переносы
            Console.WriteLine($"\nВаше Имя: {firstname} \nВаша Фамилия: {name} \nВаш Возраст: {age} \nВаш Вес: {weight} \nРаботаете? {(workA ? work : Work0)}");   //Вывод на консоль
            Console.ReadKey();
            
            //TODO - убрать лишние отступы



        }
    }
}
