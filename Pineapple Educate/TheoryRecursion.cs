namespace Pineapple_Educate;

// Рекурсия.
public class TheoryRecursion
{
    // Пример рекурсии - обращение функции к самой себе
    private int SumNumbers(int value)
    {
        if (value < 10)
        {
            return value;
        }

        return SumNumbers(value / 10) + value % 10;
    }
    
    // Пример рекурсии - подсчёт факториала
    private int Factorial(int n)
    {
        if (n == 1) return 1;
 
        return n * Factorial(n - 1);
    }
    
    // Объявление класса с подвложенным данным классом
    public class Item
    {
        public int Value { get; set; }
        public Item? Child { get; set; }
    }

    // Заполнение вложенности рекурсивного элемента
    public Item InitItem()
    {
        return new Item()
        {
            Value = 5,
            Child = new Item()
            {
                Value = 10,
                Child = new Item()
                {
                    Value = 2
                }
            }
        };
    }

    // Обращение к вложенному элементу
    public void Print(Item? item)
    {
        if (item != null)
        {
            Console.WriteLine(item.Value);
            Print(item.Child);
        }
    }
}