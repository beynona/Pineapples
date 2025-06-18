namespace Pineapple_Educate;

// Nullable - типы
public class TheoryNullable
{
    // Null у значимых типов
    private void NullableOperator()
    {
        int? i = null; // ? - показывает, что в переменной может храниться null

        Console.WriteLine(i == null); // True
        Console.WriteLine(i.HasValue); // False
        Console.WriteLine(i.GetValueOrDefault()); // 0
        Console.WriteLine(i.GetValueOrDefault(3)); // 3
        Console.WriteLine(i ?? 55); // 55
        Console.WriteLine(i.Value); // Error: InvalidOperationException
    }

    // Оператор ?? проверяет ссылочные данные на null, иначе дефолтное поведение
    private void NullOp()
    {
        string? str = null;
        Console.WriteLine(str ?? "нет данных");

        // Оператор ??= присваивает новое значение, если текущее null
        string? st = null;
        st ??= "Hello";
        Console.WriteLine(st);
    }
}