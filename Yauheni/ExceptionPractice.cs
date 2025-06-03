namespace Yauheni;

public class ExceptionPractice : Exception
{
    public int Value { get; }
    public ExceptionPractice(string message, int value) : base(message)
    {
        Value = value;
    }

    public ExceptionPractice()
    {
        
    }
}

public static class CodeWithException
{
    public static void ErrorsCode(int age = 0)
    {
        Console.WriteLine($"Попытка обработать с возрастом {age}");
        try
        {
            if (age <= 0)
            {
                throw new ExceptionPractice("Custom error", age);
            }
            Console.WriteLine("No errors");
        }
        catch (ExceptionPractice e)
        {
            Console.WriteLine($"{e.Message} потому что ваш возраст {age}");
        }
        finally
        {
            Console.WriteLine("Finally");
        }

        Console.WriteLine("End method. \n___");
    }
}