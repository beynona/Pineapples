namespace Yauheni;

internal static class Program
{
    public static void Main()
    {
        // Практика с массивами
        ArrayTest();
    }

    private static void ArrayTest()
    {
        // объявление изначального массива
        int[] testArray = { 2, 4, 5 };
        Helpers.ConsoleHelper(testArray, "Изначальный массив: ");
        
        // Тест добавления элемента в середину массива
        ArrayPractice.Insert(ref testArray, 99, 2);
        Helpers.ConsoleHelper(testArray, "Массив с новым элементом на 2 индексе: ");
        
        // Тест добавления элемента в начало массива
        ArrayPractice.AddFirst(ref testArray, 17);
        Helpers.ConsoleHelper(testArray, "Массив с новым элементом на 0 индексе: ");
    }

  
}