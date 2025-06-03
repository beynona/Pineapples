namespace TestProjects;

internal interface ICar
{
    /// <summary>
    /// Выполнить перемещение
    /// </summary>
    /// <param name="distance"> дистанция</param>
    double Move(int distance);
}

public class Lada : ICar
{
    public double Move(int distance)
    {
        double speed = distance / 60.0;
        Console.WriteLine($"{speed}");
        
        return speed;
    }
}

public class BmwSeven : ICar
{
    public double Move(int distance)
    {
        double speed = distance / 40.0;
        Console.WriteLine($"{speed}");
        
        return speed;
    }
}