namespace Yauheni;

public class LambdaPractice
{
    public delegate int MyHandler(int i);
    public void LessonPractice()
    {
        var lesson = new Lesson("Educated c#");
        // Анонимный метод
        lesson.Started += (sender, time) =>
        {
            Console.WriteLine($"sender: {sender}");
            Console.WriteLine($"date: {time}");
        };
        lesson.Start();


        var list = new List<int>();
        for (int i = 0; i < 20; i++)
        {
            list.Add(i);
        }

        var result = Agr(list, Sum);
        Console.WriteLine($"Agr result: {result}");

        var lambdaResult = Agr(list, x => x + x);
        Console.WriteLine($"LambdaResult result: {lambdaResult}");
    }
    
    //Агрегатные методы
    public int Agr(List<int> list, MyHandler handler)
    {
        int result = 0;
        foreach (var item in list)
        {
            result += handler(item);
        }

        return result;
    }

    private int Sum(int i)
    {
        return i + i;
    }
}

class Lesson
{
    public string Name { get; }
    public DateTime Begin { get; private set; }

    public event EventHandler<DateTime> Started;

    public Lesson(string name)
    {
        Name = name;
    }

    public void Start()
    {
        Begin = DateTime.Now;
        Started?.Invoke(this, Begin);
    }

    public override string ToString()
    {
        return Name;
    }
}