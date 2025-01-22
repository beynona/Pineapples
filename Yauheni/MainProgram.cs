namespace Yauheni;

internal static class Program
{
    public static void Main()
    {
        // Практика с массивами
        // ArrayTest();
        
        //Практика с наследованием
        InheritanceTest();
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

    private static void InheritanceTest()
    {
        // Базовый класс
        InheritancePractice.Person person = new InheritancePractice.Person
        {
            Name = "Bill",
            LastName = "Gate"
        };
        person.Display();
        
        // Класс наследник - имеет функционал класса Person
        InheritancePractice.Employee employee = new InheritancePractice.Employee
        {
            Name = "Jorj",
            LastName = "Shunk",
            Company = "MC"
        };
        employee.Display();
        
        //Вариант конструктора через base
        InheritancePractice.Employee testEmployee = new InheritancePractice.Employee(
            "Ivan",
            "Lohi",
            "Dinamo");

    }

  
}