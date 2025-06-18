namespace Pineapple_Educate;

// Базовый класс.
internal static class Program
{
    public static void Main()
    {
        AsyncTestTheory(); // Theory in async
    }

    private static void AsyncTestTheory()
    {
        TheoryAsync async = new TheoryAsync();
        async.MainAsyncPractice();
    }
}