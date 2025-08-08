using System.Collections;

namespace Yauheni;

// Методы расширения нужны, когда надо расширить дополнительными методами встроенные типы данных
public class ExtensionMethodsPractice
{
    public void MainTest()
    {
        // Использование функций внутри класса
        int a = 6;
        var result = IsEven(a);

        // Использование методов расширения
        var resultExt = a.IsEven();
        Console.WriteLine($"Число {a} чётное: {resultExt}");
        var resultDivided = a.IsDividedBy(4);
        Console.WriteLine($"Число {a} делится на 4: {resultDivided}");
    }

    public void ConvertersPractice()
    {
        var roads = new List<Road>();
        for (int i = 0; i < 10; i++)
        {
            Road newRoad = new Road();
            newRoad.CreateRandomRoad(10, 15);
            roads.Add(newRoad);
        }

        var roadsName = roads.ConvertToString();
        Console.WriteLine($"{roadsName}");
    }
   
    //Проверка числа на чётность
    static bool IsEven(int i)
    {
        return i % 2 == 0;
    }
}

// Создание методов расширения
// Работает только внутри пространства имён
public static class HelpersExtension
{
    // Для первого параметра метода необходимо использовать this перед нужным типом для расширения
    public static bool IsEven(this int i)
    {
        return i % 2 == 0;
    }

    public static bool IsDividedBy(this int i, int j)
    {
        return i % j == 0;
    }

    public static string ConvertToString(this IEnumerable collection)
    {
        var result = "";

        foreach (var item in collection)
        {
            result += item.ToString() + ", \r\n";
        }

        return result;
    }

    public static Road CreateRandomRoad(this Road road, int maxNumber, int maxLength)
    {
        var rnd = new Random();
        road.Number = "M" + rnd.Next(1, maxNumber);
        road.Length = rnd.Next(1, maxLength);
        return road;
    }
}

// Класс помечен как запечатан и от него нельзя унаследоваться - sealed
// Когда не можем создать класс наследник удобно использовать методы расширения
public sealed class Road
{
    public string Number { get; set; } 
    public int Length { get; set; }

    public override string ToString()
    {
        return $"Дорога {Number} длиной {Length}";
    }
}