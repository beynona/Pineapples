using System.Collections;

namespace Yauheni;

// Индексаторы - обращение к элементам коллекции по индексу

// Форма записи:
// public тип this[тип индекс] { get { } set { }}

// yield - реализация доступа для пересчёта элементов коллекции
public class IndexerAndYieldPractice
{
    public void TestCarsParking()
    {
        var cars = new List<Car>()
        {
            new Car(){Name = "Ford", Number = "A001AA01"},
            new Car(){Name = "Audi", Number = "B041AB04"}
        };

        var parking = new Parking();

        foreach (var car in cars)
        {
            parking.Add(car);
        }
        
        // Вывод авто с парковки
        foreach (var car in parking)
        {
            Console.WriteLine($"Перебор через IEnumerable: {car}");
        }

        // Обращение к парковке по индексу для поиска авто
        Console.WriteLine($"Существующее авто по индексу: {parking["A001AA01"]?.Name}");
        Console.WriteLine($"Не существующее авто по индексу: {parking["A001AA02"]?.Name}");

        Console.Write("Введите номер нового авто: ");
        var number = Console.ReadLine();
        parking[1] = new Car() { Name = "BMW", Number = number };
        Console.WriteLine($"Новый авто под индексом 1: {parking[1]}");

        foreach (var name in parking.GetCarNames())
        {
            Console.WriteLine($"car name:{name}");
        }
    }
}

public class Car
{
    public string Name { get; set; }
    public string Number { get; set; }

    public override string ToString()
    {
        return Name + " " + Number;
    }
}

// Для того, чтобы класс работал с циклом foreach необходима реализация IEnumerable
// IEnumerable просто возвращает коллекцию (IEnumerator).
// Но так как мы работаем с готовой коллекцией нет необходимости писать всё самостоятельно,
// достаточно использовать инумератор списка наших машин
public class Parking : IEnumerable<Car>
{
    private List<Car> _cars = new();
    private const int MAX_CARS = 100;

    private int Count => _cars.Count;
    public string Name { get; set; }

    // ИНДЕКСАТОР получения авто на парковке
    public Car this[string number]
    {
        get
        {
            return _cars.FirstOrDefault(car => car.Number == number);
        }
    }
    
    public Car this[int position]
    {
        get
        {
            if (position < Count)
            {
                return _cars[position];
            }
            return null;
        }
        set
        {
            // Замена авто на парковке
            if (position < Count)
            {
                _cars[position] = value;
            }  
        }
    }

    public int Add(Car car)
    {
        if (car == null)
        {
            throw new ArgumentNullException(nameof(car), "Car is null");
        }

        if (Count < MAX_CARS)
        {
            _cars.Add(car);
            return Count - 1;
        }

        return -1;
    }

    public void GoOut(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
        {
            throw new ArgumentNullException(nameof(number), "Number is null or space");
        }

        var car = _cars.FirstOrDefault(car => car.Number == number);
        if (car != null)
        {
            _cars.Remove(car);
        }
    }
    
    // Возвращать элементы коллекции через ключевое слово yield
    public IEnumerable GetCarEnumerator()
    {
        foreach (var car in _cars)
        {
            yield return car;
        }
    }
    
    // Возвращать элементы коллекции через ключевое слово yield
    public IEnumerable GetCarNames()
    {
        foreach (var car in _cars)
        {
            yield return car.Name;
        }
    }

    // Получить перечисление
    public IEnumerator<Car> GetEnumerator()
    {
       return _cars.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _cars.GetEnumerator();
    }
}

// IEnumerator - перебор коллекции, может брать текущий элемент и что-то с ним делать.
// Последовательно перебирает от первого элемента к другому
public class ParkingEnumerator : IEnumerator
{
    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public object Current { get; }
}