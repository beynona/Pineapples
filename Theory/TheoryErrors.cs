namespace Pineapple_Educate;

public class TheoryErrors
{
    public void ErrorsOnTryCatch()
    {
        // ожидаемая операция
        try
        {
            int a = 5;
            int b = a / 0;
        }
        // тип_исключения исключение
        catch (DivideByZeroException e)
        {
            Console.WriteLine("Попытка деления на 0");
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        // действия после выполнения в try и catch
        finally
        {
            Console.WriteLine("Finally");
        }
    }
}