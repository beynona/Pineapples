namespace Yauheni;

public class AnonymousTypesPractice
{
    delegate int MyHandle(int i);
    public void AnonymousMethods()
    {
        Console.WriteLine("Введите число:");
        if (int.TryParse(Console.ReadLine(),out int result))
        {
            // Анонимные методы
            // Объявление к анонимному методу можно только через дегелат
            // Объявление реализации в том месте, где используем и нигде больше
            MyHandle handler = delegate(int i)
            {
                var res = i * i;
                Console.WriteLine($"Анонимный вызов делегата {res}");
                return res;
            };
            handler += Method;
            handler(result);
        }
    }

    public int Method(int i)
    {
        var res = i * i * i;
        Console.WriteLine($"Method {res}");
        return res;
    }
    
    public void AnonymousTypes()
    {
        // Объявление анонимных типов с заданными свойствами только get;
        var product = new 
            { 
                Name = "Milk", 
                Energy = 10 
            };
        Console.WriteLine($"Анонимный тип 1: {product}");

        var eat = new Eat()
        {
            Name = "Meat"
        };
        var product2 = new
        {
            eat.Name, // то же самое, что и Name = "Meat"
            Energy = 200
        };
        Console.WriteLine($"Анонимный тип 2: {product2}");
    }
}

public class Eat
{
    public string Name { get; set; }
}