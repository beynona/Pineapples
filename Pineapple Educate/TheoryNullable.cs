namespace Yauheni;

public class TheoryNullable
{
    public void NullableOp()
    {
        int? i = null; // ? - показывает, что в переменной может храниться null
        
        Console.WriteLine(i == null); // True
        Console.WriteLine(i.HasValue); // False
        Console.WriteLine(i.GetValueOrDefault()); // 0
        Console.WriteLine(i.GetValueOrDefault(3)); // 3
        Console.WriteLine(i ?? 55); // 55
        Console.WriteLine(i.Value); // Error: InvalidOperationException
    }
}