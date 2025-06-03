namespace Yauheni;

public class ExceptionPractice : Exception
{
    public ExceptionPractice(string message) : base(message)
    {
    }

    public ExceptionPractice()
    {
        
    }
}

public static class CodeWithException
{
    public static void ErrorsCode(int age = 0)
    {
        try
        {
            if (age <= 0)
            {
                throw new ExceptionPractice("Custom error");
            }
        }
        catch (ExceptionPractice e)
        {
            Console.WriteLine(e.Message);
        }
    }
}