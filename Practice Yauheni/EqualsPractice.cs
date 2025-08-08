namespace Yauheni;

public class EqualsPractice
{
    // Объект одинаковые, но имеют разные ссылки в куче, поэтому необходимо переопределять equals
    public void EqualPractice()
    {
        var p1 = new Point() { X = 5 };
        var p2 = new Point() { X = 5 };
        Console.WriteLine($"Без переопределения equals: p1({p1.X}) = p2({p2.X}) ? {p1.Equals(p2)}");
        
        var op1 = new OverPoint() { X = 5 };
        var op2 = new OverPoint() { X = 5 };
        Console.WriteLine($"После переопределения equals: op1({op1.X}) = op2({op1.X}) ? {op1.Equals(op2)}");
    }
}

class Point
{
    public int X { get; set; }
}

class OverPoint
{
    public int X { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is OverPoint point)
        {
            return X == point.X;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return X;
    }
}