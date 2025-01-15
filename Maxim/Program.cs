using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationVS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите Имя: ");                            // Отображение в консоли
            string firstname = Console.ReadLine();                     // Ввод с консоли
            Console.Write("Введите Фамилию: ");
            string name = Console.ReadLine();
            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());                  //Парсинг в целые числа
            Console.Write("Введите свой вес: ");
            double weight = double.Parse(Console.ReadLine());          //Парсинг в дробные числа
            Console.Write("Работате? (Да/Нет) ");
            string work = Console.ReadLine();
            bool workA = (work == "да" || work == "Нет");
            const string Work0 = " Не определился ";

            Console.WriteLine($"\nВаше Имя: {firstname} \nВаша Фамилия: {name} \nВаш Возраст: {age} \nВаш Вес: {weight} \nРаботаете? {(workA ? work : Work0)}");   //Вывод на консоль
            Console.ReadKey();




        }
    }
}
