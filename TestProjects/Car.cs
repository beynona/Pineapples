namespace TestProjects;

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