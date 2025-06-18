namespace Yauheni;

internal static class Program
{
    public static void Main()
    {
        // ArrayTest(); // Практика с массивами
        // InheritanceTest(); // Практика с наследованием
        // DelegateTest(); // Практика с делигатами
        // CodeWithException.ErrorsCode(0); // Практика с отловом ошибок - С ошибкой
        // CodeWithException.ErrorsCode(1); // Практика с отловом ошибок - Без ошибкой
        // EventsTest(); // Практика с событиями
        // StreamTest(); // Работа с файлами
        AsyncTest(); // Работа с async
    }

    private static void AsyncTest()
    {
        AsyncPractice asyncPractice = new AsyncPractice();
        asyncPractice.AsyncPracticeMain();
    }

    private static void StreamTest()
    {
        StreamPractice sp = new StreamPractice();
        
        sp.WriteAndReadFromFile();
    }
    
    private static void EventsTest()
    {
        EventsPractice person = new EventsPractice
        {
            Name = "Jenua"
        };
        person.GoToSleep += PersonOnGoToSleep;
        person.DoWork += PersonOnDoWork;
        // Оповещаем DoWork
        person.OnGoToSleep(new DateTime(2015, 11, 15, 18, 55, 55));
        // Оповещаем всех подписчиков, что произошло событие GoToSleep
        person.OnGoToSleep(new DateTime(2015, 11, 15, 23, 55, 55));
    }

    private static void PersonOnDoWork(object? sender, EventArgs e)
    {
        if (sender is EventsPractice)
        {
            Console.WriteLine($"{((EventsPractice)sender).Name} работает работу");
        }
    }

    private static void PersonOnGoToSleep()
    {
        Console.WriteLine("Человек пошёл спать");
    }

    private static void DelegateTest()
    {
        DelegatePractice delegatePractice = new DelegatePractice();
        // без регистрации делегата
        delegatePractice.PrintMessage();
        
        // с регистрацией делигата
        delegatePractice.RegisterMessageHandler(ConsolePrint);
        delegatePractice.PrintMessage();
        
        
        //тестовый метод для делегата
        void ConsolePrint(string message)
        {
            Console.WriteLine(message);
        }
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