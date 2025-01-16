namespace Yauheni;

public class TheoryOverloadMethods
{
    // Перегрузка позволяет использовать одинаковые имена методов,
    // но с разными параметрами и их количеством
    
    private int Sum(int a, int b)
    {
        return a + b;
    }

    private int Sum(int a, int b, int c)
    {
        return a + b + c;
    }
    
    private double Sum(double a, double b, double c)
    {
        return a + b + c;
    }
}