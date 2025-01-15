using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите два числа:");
            const string Null = "0";
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            bool res1 = double.TryParse(x, out var number1);
            bool res2 = double.TryParse(y, out var number2);
            if (res1 & res2)
            {
                double a = Convert.ToDouble(x);
                double b = Convert.ToDouble(y);
                double del = a / b;
                double mnozh = a * b;
                double sum = a + b;
                double min = a - b;
                Console.Clear();
                Console.WriteLine($"Сумма чисел:{sum} \nПроизведение чисел:{mnozh} \nРазность чисел:{min} \nДеление чисел:{del}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine(Null);
            }
            Console.ReadLine();
        }






    }
}
