using System.Collections;
using System.Net;
using System.Security;

namespace AnyPractice;

public class ThemesPractice
{
    public void NullPr()
    {
        Console.WriteLine("Null PR");
        
        string? name = null;
        string defaultName = "Unknown";

        // ?? обозначает - если левая сторона null, то используем правую
        string result = name ?? defaultName;
        Console.WriteLine(result);

        Console.WriteLine();
    }
    
    // Если нужно выгружать данные с интернета
    public void WebClientPr()
    {
        Console.WriteLine("WebClient PR");
        
        WebClient user = new WebClient();
        string uri = "https://teletype.in/@maddevelop/ByQG3NVBE";
        string fileName = "data.txt";

        try
        {
            Console.WriteLine($"Загрузка данных по адресу {uri} в файл {fileName}");
            user.DownloadFile(uri,fileName);
            Console.WriteLine("Загрузка завершена");
        }
        catch (WebException e)
        {
            Console.WriteLine(e.Message);
        }
        
        Console.WriteLine();
    }
    
    // Основы организации доступа к интернету
    public void WebPr()
    {
        Console.WriteLine("Web Errors PR");
        
        try
        {
            WebRequest request = WebRequest.Create(new Uri("google.com"));
            WebResponse response = request.GetResponse();

            Stream stream = response.GetResponseStream();
            int ch = stream.ReadByte();

            for (int i = 0; i < ch; i++)
            {
                Console.WriteLine(ch);
            }
        }
        catch (UriFormatException exc)
        {
            Console.WriteLine($"Ошибка формата URI: {exc.Message}");
        }
        catch (ProtocolViolationException exc)
        {
            Console.WriteLine($"Протокольная ошибка: {exc.Message}");
        }
        catch (NotSupportedException exc)
        {
            Console.WriteLine($"Неизвестный протокол: {exc.Message}");
        }
        catch (IOException exc)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {exc.Message}");
        }
        catch (SecurityException exc)
        {
            Console.WriteLine($"Исключение в связи с нарушением безопасности: {exc.Message}");
        }
        catch (Exception exc)
        {
            Console.WriteLine($"Сторонняя ошибка: {exc.Message}");
        }
        
        Console.WriteLine();
    }

    // Перечисление объектов циклом - 1 метод GetEnumerator
    public void EnumerablePr()
    {    
        Console.WriteLine("IEnumerable PR");

        EnumerableForTest iteratorsForTest = new EnumerableForTest();
        foreach (var iterator in iteratorsForTest)
        {
            Console.Write($"{iterator} ");
        }
        
        Console.WriteLine();
    }
    
    // Перечисление объектов циклом - 3 метода MoveNext, Reset и Current
    public void EnumeratorPr()
    {    
        Console.WriteLine("IEnumerator PR");

        EnumeratorForTest iteratorsForTest = new EnumeratorForTest();
        foreach (var iterator in iteratorsForTest)
        {
            Console.Write($"{iterator} ");
        }
        
        Console.WriteLine();
    }

    // Интерфейс содержащий метод сравнение объектов в коллекции
    // Если требуется отсортировать объекты в коллекции
    // Интерфейс реализует метод CompareTo
    // Для сортировки в нашей коллекции вызываем метод .Sort()
    public void ComparablePr()
    {
        Console.WriteLine("IComparable PR");

        List<InventoryForComparable> inventories = new List<InventoryForComparable> 
        {
            new("Дрель", 5.95, 3),
            new("Шуруповёрт", 15, 2),
            new("Молоток", 11, 4),
            new("Отвёртка", 14, 11)
        };

        Console.WriteLine("Товары до сортировки: ");
        foreach (var inventory in inventories)
        {
            Console.WriteLine(inventory);
        }
        
        // Сортировка элементов коллекции
        inventories.Sort();
        Console.WriteLine();
        
        Console.WriteLine("Товары после сортировки: ");
        foreach (var inventory in inventories)
        {
            Console.WriteLine(inventory);
        }
        
        Console.WriteLine();
    }
    
    // Предназначен для хранения элементов, в качестве элементов служит хэш-таблица
    // Хэш-код служит в качестве индекса и является уникальным
    public void HashtablePr()
    {    
        Console.WriteLine("Hashtable PR");

        Hashtable hashtable = new Hashtable()
        {
            { "Яблоко", "Фрукт" },
            { "Машина", "Транспорт" },
            { "Книга", "Печатное средство" },
            { "Здание", "Жилое помещение" },
        };
        foreach (var key in hashtable.Keys)
        {
            Console.WriteLine($"{key} - {hashtable[key]}");  
        }
        
        Console.WriteLine();
    }
    
    // Предназначен для хранения элементов отсортированных по ключу
    public void SortedListPr()
    {    
        Console.WriteLine("SortedList PR");

        SortedList sortedList = new SortedList()
        {
            { "Яблоко", "Фрукт" },
            { "Машина", "Транспорт" },
            { "Книга", "Печатное средство" },
            { "Здание", "Жилое помещение" },
        };
        foreach (var key in sortedList.Keys)
        {
            Console.WriteLine($"{key} - {sortedList[key]}");  
        }
        
        Console.WriteLine();
    }
    
    // Стек: первым пришёл - последним вышел
    public void StackPr()
    {    
        Console.WriteLine("Stack PR");

        Stack stack = new Stack();
        
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.Write("Содержимое стека: ");
        foreach (var s in stack)
        {
            Console.Write($"{s} ");
        }
        Console.WriteLine();
        stack.Pop();
        Console.Write("Содержимое стека после извлечения: ");
        foreach (var s in stack)
        {
            Console.Write($"{s} ");
        }
        
        Console.WriteLine("\r\n");
    }
    
    // Очередь: первым пришёл - первым вышел
    public void QueuePr()
    {    
        Console.WriteLine("Queue PR");

        Queue queue = new Queue();
        
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Console.Write("Содержимое очереди: ");
        foreach (var s in queue)
        {
            Console.Write($"{s} ");
        }
        Console.WriteLine();
        queue.Dequeue();
        Console.Write("Содержимое очереди после извлечения: ");
        foreach (var s in queue)
        {
            Console.Write($"{s} ");
        }
        
        Console.WriteLine("\r\n");
    }
    
    // Параллельное выполнение linq операций в нескольких потоках
    public void PLinqPr()
    {
        Console.WriteLine("Parallel linq PR");

        int[] data = new int[1000000];
        Console.WriteLine($"Всего элементов в массиве:{data.Length}");
        for (int i = 0; i < data.Length; i++)
        {
            int temp = i;
            if (i % 100009 == 0)
            {
                temp *= -1;
            }
            data[i] = temp;
        }

        var negative = from value in data.AsParallel()
            where value < 0
            select value;

        Console.Write("Список отрицательных элементов: ");
        foreach (var number in negative)
        {
            Console.Write($"{number} ");
        }
        
        Console.WriteLine("\r\n");
    }
}

class EnumerableForTest : IEnumerable
{
    private readonly char[] _chars = { 'A', 'B', 'C', 'D' };

    public IEnumerator GetEnumerator()
    {
        foreach (var ch in _chars)
            yield return ch;
    }
}

class EnumeratorForTest : IEnumerator
{
    private readonly char[] _chars = { 'A', 'B', 'C', 'D' };
    private int _index = -1;

    public IEnumerator GetEnumerator()
    {
        return this;
    }
    
    public bool MoveNext()
    {
        if (_index == _chars.Length -1)
        {
            Reset();
            return false;
        }

        _index++;
        return true;
    }

    public void Reset()
    {
        _index = -1;
    }

    public object Current => _chars[_index];
}

class InventoryForComparable : IComparable<InventoryForComparable>
{
    private string Name;
    private double Cost;
    private int Onhand;

    public InventoryForComparable(string name,double cost, int hand)
    {
        Name = name;
        Cost = cost;
        Onhand = hand;
    }

    // Реализация метода для сортировки элементов коллекции по имени
    public int CompareTo(InventoryForComparable obj)
    {
        return Name.CompareTo(obj.Name);
    }

    public override string ToString()
    {
        return $"{Name} Стоимость:{Cost} Наличие:{Onhand}";
    }
}