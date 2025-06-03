namespace TestProjects;

public abstract class Products
{
    private string Name { get; }
    protected int Calorie { get; }
    protected int Amount { get; }

    public Products(string name, int calorie, int amount)
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
    public Apple(string name, int calorie, int amount) : base(name, calorie, amount)
    {
    }

    // Перегрузка базовых операторов
    public static Apple operator+ (Apple firstApple, Apple secondApple)
    {
        int newAppleCalories = firstApple.Calorie + secondApple.Calorie;
        int newAppleAmount = firstApple.Amount + secondApple.Amount;
        var newApple = new Apple(DefaultAppleName, newAppleCalories, newAppleAmount);
        return newApple;
    }
}