namespace Yauheni;

public class ValueTuplePractice
{
    public void TuplePractice()
    {
        // Объявление кортежа Tuple, параметры только для get;
        Tuple<int, string> tuple = new Tuple<int, string>(5, "Milk");
        Console.WriteLine($"tuple Item1:{tuple.Item1}, Item2:{tuple.Item2}");

        var result = GetData();
        var item1 = result.Item1;
        
        var result2 = GetNamedData();
        var namedItem1 = result2.Name;
    }

    // Получение базового кортежа
    private (int, string, bool) GetData()
    {
        var number = 5;
        var name = "Jenua";
        var isMale = true;

        return (number, name, isMale);
    }
    
    // Получение именнованного кортежа
    private (int Number, string Name, bool Flag) GetNamedData()
    {
        var number = 5;
        var name = "Jenua";
        var isMale = true;

        return (number, name, isMale);
    }
    
}