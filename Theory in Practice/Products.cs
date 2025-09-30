namespace AnyPractice;

public abstract class Products
{
    private string Name { get; }
    protected internal double Calorie { get; }
    protected internal int Amount { get; }

    protected Products(string name, double calorie, int amount)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (calorie < 0)
        {
            throw new ArgumentNullException(nameof(calorie));
        }
        
        if (amount < 0)
        {
            throw new ArgumentNullException(nameof(amount));
        }

        Name = name;
        Calorie = calorie;
        Amount = amount;
    }
    
    public override string ToString()
    {
        return $"Name: {Name}, Calorie: {Calorie}, Amount: {Amount}";
    }
}

public static class ProductHelpers
{
    public static void CalculateCalories()
    {
        Apple firstApple = new Apple("Red Apple", 5, 6);
        Console.WriteLine($"First apple: {firstApple}"); // Вывод имени 1 объекта
        
        Apple secondApple = new Apple("Green Apple", 6, 2);
        Console.WriteLine($"First apple: {secondApple}");   // Вывод имени 2 объекта

        Apple sumApples = firstApple + secondApple;
        Console.WriteLine($"Sum apples: {sumApples}");

        Eating<Apple> eating = new Eating<Apple>(); // Тест дженериков (обобщений)
        eating.Add(firstApple);
        Console.WriteLine($"Eating first apple: {eating}");
        eating.Add(secondApple);
        Console.WriteLine($"Eating second apple: {eating}");
    }
}

public class Apple : Products
{
    private const string DefaultAppleName = "Apple";

    public Apple(string name, double calorie, int amount) : base(name, calorie, amount)
    {
    }

    // Перегрузка базовых операторов
    public static Apple operator +(Apple firstApple, Apple secondApple)
    {
        double newAppleCalories = firstApple.Calorie + secondApple.Calorie;
        int newAppleAmount = firstApple.Amount + secondApple.Amount;
        
        return new Apple(DefaultAppleName, newAppleCalories, newAppleAmount);
    }
}

public class Eating<T> where T : Products
{
    private double Volume { get; set; }

    public void Add(T product)
    {
        Volume += product.Amount * product.Calorie;
    }

    public override string ToString()
    {
        return $"{Volume}";
    }
}