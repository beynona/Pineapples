namespace AnyPractice;

internal interface ICar
{
    /// <summary>
    /// Выполнить перемещение
    /// </summary>
    /// <param name="distance"> дистанция</param>
    void Move(int distance);
}

public class Lada : ICar
{
    public void Move(int distance)
    {
        double speed = distance / 60.0;
        Console.WriteLine($"{speed}");
    }
}

public class BmwSeven : ICar
{
    public void Move(int distance)
    {
        double speed = distance / 40.0;
        Console.WriteLine($"{speed}");
    }
}

public static class CarHelpers
{
    public static void AnyCarMove()
    {
        List<ICar> cars = new List<ICar>
        {
            new Lada(),
            new BmwSeven()
        };

        foreach (var car in cars)
        {
            car.Move(155);
        }
    }
}