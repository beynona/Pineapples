namespace TestProjects;

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
        Apple newApple = new Apple(DefaultAppleName, newAppleCalories, newAppleAmount);
        return newApple;
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