namespace Pineapple_Educate;

public class TheoryAsync
{
    // Для работы с асинхронным программированием используются ключевые слова async await
    
    /* Output:
        Begin Main
        Begin async
        Begin DoWork
        DoWork
        DoWork
        DoWork
        DoWork
        DoWork
        DoWork
        DoWork
        DoWork
        DoWork
        DoWork
        End DoWork
        Continue Main
        Main
        End async
        Main
        Main
        Main
        Main
        Main
        Main
        Main
        Main
        Main
        End Main
     */
    
    public void MainAsyncPractice()
    {
        Console.WriteLine("Begin Main");
        DoWorkAsync();
        Console.WriteLine("Continue Main");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Main");
        }
        
        Console.WriteLine("End Main");
    }
    
    async Task DoWorkAsync()
    {
        Console.WriteLine("Begin async");
        await Task.Run(DoWork);
        Console.WriteLine("End async");
    }

    private void DoWork()
    {
        Console.WriteLine("Begin DoWork");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("DoWork");
        }
        Console.WriteLine("End DoWork");
    }
}