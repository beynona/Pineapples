namespace Yauheni;

// Изучение System.Linq.Enumerable
public class LinqPractice
{
    // Union - объединение уникальных элементов из 2 коллекций 
    // arr1.Union(arr2)
    
    // Intersect - пересечение коллекций. Элементы, что есть в 1 и во 2 множестве
    // arr1.Intersect(arr2)
    
    // Except - разность коллекций. Элементы, что есть в 1 множестве, но нет во 2
    // arr1.Except(arr2)
    
    // Min - минимальный элемент коллекции
    // arr.Min(p => p)
    
    // Max - максимальный элемент коллекции
    // arr.Max(p => p)
    
    // Sum - сумма элементов коллекции
    // arr.Sum()
    
    // Skip - пропустить заданное количество элементов коллекции
    // arr.Skip(1)
    
    // Take - Сколько элементов нужно взять из коллекции
    // arr.Take(2)
    
    // First - берём 1 элемент из коллекции, но если коллекция пуста, то словим ошибку
    // arr.First()
    
    // FirstOrDefault - берём 1 элемент из коллекции, но если коллекция пуста, то присвоится значение по умолчанию
    // Значения по умолчанию: для int - 0, для class - null и тд
    // arr.FirstOrDefault()
    
    // Last - берём последний элемент из коллекции, но если коллекция пуста, то словим ошибку
    // arr.First()
    
    // LastOrDefault - берём последний элемент из коллекции, но если коллекция пуста, то присвоится значение по умолчанию
    // Значения по умолчанию: для int - 0, для class - null и тд
    // arr.FirstOrDefault()
    
    // Single - операция требует, чтобы элемент, удовлетворяющий условию, был единственный в коллекции, иначе exception
    // Пример: при получении данных с бд мы точно знаем, что идентификатор должен быть уникальным и единственным
    // arr.Single(product => product.Energy == 10)
    
    // ElementAt - получить элемент по индексу (по номеру элемента в коллекции)
    // arr.ElementAt(4)
    
    public void AllAnyContainsLinq()
    {
        var rnd = new Random();
        var products = new List<Product>();

        for (int i = 0; i < 10; i++)
        {
            products.Add(new Product()
            {
                Name = $"Product {rnd.Next(1, 10)}",
                Energy = rnd.Next(5, 7)
            });
        }
        Console.WriteLine("Базовая коллекция: ");
        // Вывод базовой коллекции на экран
        foreach (var item in products)
        {
            Console.WriteLine($"{item} ");
        }

        // All - все из коллекции соответствуют условию
        // Any - любое из коллекции соответствует условию
        // Contains - коллекция содержит элемент условия
        Console.WriteLine($"All 6: {products.All(item => item.Energy == 6)}");
        Console.WriteLine($"Any 6: {products.Any(item => item.Energy == 6)}");
        Console.WriteLine($"Contains new: {products.Contains(new Product())}");
        Console.WriteLine($"Contains 1 elem: {products.Contains(products[1])}");
    }

    // Distinct - коллекция из уникальных элементов
    public void DistProduct()
    {
        var products = new List<Product>()
        {
            new() { Name = "1"}, 
            new() { Name = "2"},
            new() { Name = "3"},
            new() { Name = "2"},
        };
        Console.WriteLine("Базовая коллекция: ");
        // Вывод базовой коллекции на экран
        foreach (var item in products)
        {
            Console.WriteLine($"{item} ");
        }

        Console.WriteLine("Коллекция после Distinct: ");
        var result = products.Distinct();
        foreach (var item in result)
        {
            Console.WriteLine($"{item} ");
        }
    }
    
    public void LinqInProduct()
    {
        var rnd = new Random();
        var collection = new List<Product>();

        for (int i = 0; i < 10; i++)
        {
            collection.Add(new Product()
            {
                Name = $"Product {rnd.Next(1, 10)}",
                Energy = rnd.Next(10, 500)
            });
        }
        Console.WriteLine("Базовая коллекция: ");
        // Вывод базовой коллекции на экран
        foreach (var item in collection)
        {
            Console.WriteLine($"{item} ");
        }

        Console.WriteLine("Коллекция с энергией >200: ");
        // from - элемент коллекции
        // in - коллекция
        // where - условие
        // select - выбрать элементы соответствующие условию
        // orderby - упорядочивание коллеции
        var result = from item in collection
            where item.Energy > 200
            orderby item.Energy
            select item;
        // Вывод новой коллекции на экран
        foreach (var item in result)
        {
            Console.WriteLine($"{item} ");
        }
        
        // Методы расширения
        Console.WriteLine("Коллекция с энергией >200  методами расширения по уменьшению: ");
        
        // OrderBy - сортировка по возрастанию
        // OrderByDescending - сортировка по убыванию
        // ThenBy / ThenByDescending - если требуется ещё одна сортировка
        var result2 = collection.Where(item => item.Energy > 200).OrderBy(item => item.Energy).ThenByDescending(item => item.Name);
        // Вывод новой коллекции на экран
        foreach (var item in result2)
        {
            Console.WriteLine($"{item} ");
        }

        
        var products = new List<Product>();

        for (int i = 0; i < 10; i++)
        {
            products.Add(new Product()
            {
                Name = $"Продукт {i}",
                Energy = rnd.Next(10, 20)
            });
        }
        Console.WriteLine("Базовая коллекция до группировки: ");
        // Вывод базовой коллекции на экран
        foreach (var item in products)
        {
            Console.WriteLine($"{item} ");
        }
        // Группировка по ключам с одинаковым значением
        var groupByCollections = products.GroupBy(product => product.Energy);
        // Перебор группировки
        // Группа содержит общий ключ и список элементов удовлетворяющих ключу
        foreach (var group in groupByCollections)
        {
            Console.WriteLine($"Ключ: {group.Key}");
            foreach (var item in group)
            {
                Console.WriteLine($"\t{item}");
            }
        }
    }
    
    public void LinqInCollections()
    {
        var collection = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            collection.Add(i);
        }
        Console.Write("Базовая коллекция: ");
        // Вывод базовой коллекции на экран
        foreach (var item in collection)
        {
            Console.Write($"{item} ");
        }

        Console.WriteLine();
        Console.Write("Коллекция с эл >5: ");
        // from - элемент коллекции
        // in - коллекция
        // where - условие
        // select - выбрать элементы соответствующие условию
        var result = from item in collection
            where item > 5
            select item;
        // Вывод новой коллекции на экран
        foreach (var item in result)
        {
            Console.Write($"{item} ");
        }
        
        // Методы расширения
        Console.WriteLine();
        Console.Write("Коллекция с эл >5 методами расширения по уменьшению: ");
        
        // OrderBy - сортировка по возрастанию
        // OrderByDescending - сортировка по убыванию
        var result2 = collection.Where(item => item > 5).OrderByDescending(item => item);
        // Вывод новой коллекции на экран
        foreach (var item in result2)
        {
            Console.Write($"{item} ");
        }
    }
}

public class Product
{
    public string Name { get; set; }
    public int Energy { get; set; }

    public override string ToString()
    {
        return $"{Name} ({Energy})";
    }
}