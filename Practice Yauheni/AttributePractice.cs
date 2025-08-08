using System.Reflection;

namespace Yauheni;


// Основная цель - получение значений только из определённых параметров отмеченных аттрибутами
public class AttributePractice
{
    public void MainAttributePractice()
    {
        var photo = new Photo("World.png")
        {
            Path = @"C:\world.png"
        };

        // Описание типа
        // Контейнер метаданных конкретного класса
        var type = typeof(Photo);
        // Получение аттрибутов
        var attributes = type.GetCustomAttributes(false);

        foreach (var attribute in attributes)
        {
            Console.WriteLine($"class attribute: {attribute}");
        }
        
        // Получение аттрибутов из свойств
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            var propName = property.Name;
            Console.WriteLine($"property: {propName}");

            var attrs = property.GetCustomAttributes();
            foreach (var attribute in attrs)
            {
                Console.WriteLine($"{propName} property attributes: {attribute}");
            }
        }
    }
}

[Geo(10,15)]
public class Photo
{
    [Geo(5,6)]
    public string Name { get; set; }
    public string Path { get; set; }

    public Photo(string name)
    {
        Name = name;
    }
}

public class GeoAttribute : Attribute
{
    public int X { get; set; }
    public int Y { get; set; }

    public GeoAttribute() { }

    public GeoAttribute(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"{{X:{X},Y:{Y}}}";
    }
}