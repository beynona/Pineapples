namespace Yauheni;

internal static class Program
{
    public static void Main()
    {
        ArrayTest(); // Практика с массивами
        InheritanceTest(); // Практика с наследованием
        DelegateTest(); // Практика с делигатами
        CodeWithException.ErrorsCode(0); // Практика с отловом ошибок - С ошибкой
        CodeWithException.ErrorsCode(1); // Практика с отловом ошибок - Без ошибкой
        EventsTest(); // Практика с событиями
        StreamTest(); // Работа с файлами
        AsyncTest(); // Работа с async
        LinqCollectionsTest(); // Работа с linq
        ExtensionsMethodsTest(); // Работа с методами расширения
        IndexerMethodsTest(); // Работа с индексаторами
        AnonymousTypesTest(); // Работа с анонимными типами
        ValueTuplePracticeTest(); // Работа с кортежами
        LambdaPracticeTest(); // Работа с лямбда-выражениями
        AttributePracticeTest(); // Работа с атрибутами
        SerializationPracticeTest(); // Работа с сериализацией XML и JSON
        EqualsPracticeTest(); // Работа с сравнением ссылочных типов методом equals
    }

    private static void EqualsPracticeTest()
    {
        Console.WriteLine("Изучение переопределения Equals:");
        
        EqualsPractice equalsPractice = new EqualsPractice();
        equalsPractice.EqualPractice();

        Console.WriteLine("\r"); // Перенос на новую строку
    }
    private static void SerializationPracticeTest()
    {
        Console.WriteLine("Изучение Сериализации:");
        
        SerializationPractice serializationPractice = new SerializationPractice();
        serializationPractice.SerializationPracticeMain();

        Console.WriteLine("\r"); // Перенос на новую строку
    }

    private static void AttributePracticeTest()
    {
        Console.WriteLine("Изучение Атрибутов:");
        
        AttributePractice attributePractice = new AttributePractice();
        attributePractice.MainAttributePractice();

        Console.WriteLine("\r"); // Перенос на новую строку
    }

    private static void LambdaPracticeTest()
    {
        Console.WriteLine("Изучение Лямбда-функций:");
        
        LambdaPractice lambdaPractice = new LambdaPractice();
        lambdaPractice.LessonPractice();

        Console.WriteLine("\r"); // Перенос на новую строку
    }

    private static void ValueTuplePracticeTest()
    {
        Console.WriteLine("Изучение Кортежей:");
        
        ValueTuplePractice valueTuplePractice = new ValueTuplePractice();
        valueTuplePractice.TuplePractice();

        Console.WriteLine("\r"); // Перенос на новую строку
    }

    private static void AnonymousTypesTest()
    {
        Console.WriteLine("Изучение Анонимных типов:");
        
        AnonymousTypesPractice anonymousTypesPractice = new AnonymousTypesPractice();
        anonymousTypesPractice.AnonymousTypes();

        Console.WriteLine("\r"); // Перенос на новую строку

        Console.WriteLine("Изучение Анонимных методов:");
        anonymousTypesPractice.AnonymousMethods();
        
        Console.WriteLine("\r"); // Перенос на новую строку
    }

    private static void IndexerMethodsTest()
    {
        Console.WriteLine("Изучение Индексаторов и yield:");
        
        IndexerAndYieldPractice indexerAndYieldPractice = new IndexerAndYieldPractice();
        indexerAndYieldPractice.TestCarsParking();

        Console.WriteLine("\r"); // Перенос на новую строку
    }

    private static void ExtensionsMethodsTest()
    {
        Console.WriteLine("Изучение Методов расширения:");
        
        ExtensionMethodsPractice extensionMethods = new ExtensionMethodsPractice();
        extensionMethods.MainTest();

        // Перенос на новую строку
        Console.WriteLine("\r");
        
        Console.WriteLine("Изучение конвертера для Методов расширения:");
        extensionMethods.ConvertersPractice();
        
        // Перенос на новую строку
        Console.WriteLine("\r");
    }

    private static void LinqCollectionsTest()
    {
        Console.WriteLine("Изучение linq:");
        
        LinqPractice asyncPractice = new LinqPractice();
        asyncPractice.LinqInCollections();

        Console.WriteLine("\r\n");

        asyncPractice.LinqInProduct();

        Console.WriteLine("\r\n");

        asyncPractice.AllAnyContainsLinq();

        Console.WriteLine("\r\n");

        asyncPractice.DistProduct();
        
        Console.WriteLine("\r\n");
    }

    private static void AsyncTest()
    {
        Console.WriteLine("Изучение async:");
        
        AsyncPractice asyncPractice = new AsyncPractice();
        asyncPractice.AsyncPracticeMain();
        
        Console.WriteLine("\r\n");
    }

    private static void StreamTest()
    {
        Console.WriteLine("Изучение потоков:");
        
        StreamPractice sp = new StreamPractice();
        sp.WriteAndReadFromFile();
        
        Console.WriteLine("\r\n");
    }

    private static void EventsTest()
    {
        Console.WriteLine("Изучение событий:");
        
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
        
        Console.WriteLine("\r\n");
    }

    // Событие для EventsTest
    private static void PersonOnDoWork(object? sender, EventArgs e)
    {
        if (sender is EventsPractice)
        {
            Console.WriteLine($"{((EventsPractice)sender).Name} работает работу");
        }
    }
    // Событие для EventsTest
    private static void PersonOnGoToSleep()
    {
        Console.WriteLine("Человек пошёл спать");
    }

    private static void DelegateTest()
    {
        Console.WriteLine("Изучение делегатов:");
        
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
        
        Console.WriteLine("\r\n");
    }

    private static void ArrayTest()
    {
        Console.WriteLine("Изучение массивов:");
        
        // объявление изначального массива
        int[] testArray = { 2, 4, 5 };
        
        Helpers.ConsoleHelper(testArray, "Изначальный массив: ");
        // Тест добавления элемента в середину массива
        ArrayPractice.Insert(ref testArray, 99, 2);
        Helpers.ConsoleHelper(testArray, "Массив с новым элементом на 2 индексе: ");
        // Тест добавления элемента в начало массива
        ArrayPractice.AddFirst(ref testArray, 17);
        Helpers.ConsoleHelper(testArray, "Массив с новым элементом на 0 индексе: ");   
        
        Console.WriteLine("\r\n");
    }

    private static void InheritanceTest()
    {
        Console.WriteLine("Изучение наследования:");
        
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
        testEmployee.Display();
        
        Console.WriteLine("\r\n");
    }
}