namespace Pineapple_Educate;

// Enum перечисления.
public class TheoryEnum
{
    // Объявление enum перечисления
    enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
    
    // Пример работы с перечислениями
    private void DoOperation(double x, double y, Operation op)
    {
        // значение переменной result будет зависеть от переданного типа Operation
        double result = op switch
        {
            Operation.Add => x + y,
            Operation.Subtract => x - y,
            Operation.Multiply => x * y,
            Operation.Divide => x / y,
            _ => 0 // Если операция из списка не выбрана возвращаем 0
        };
        Console.WriteLine(result);
    }
    
    //Второй пример работы с enum
    private enum Numbers
    {
        First,
        Second
    };
    private void DoNumbers(Numbers switchNumber)
    {
        switch (switchNumber)
        {
            case Numbers.First:
                Console.WriteLine("First");
                break;
            case Numbers.Second:
                Console.WriteLine("Second");
                break;
            default:
                Console.WriteLine("Error");
                break;
        }
    }
}