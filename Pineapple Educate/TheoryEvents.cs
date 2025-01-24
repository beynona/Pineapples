namespace Pineapple_Educate;

// События event.
// Каждое событие должно представлять определённый делегат 

// если событие до того, как произошло действие, то к глаголу добавляем -ing
// если событие после того, как произошло действие, то к глаголу добавляем -ed
public class TheoryEvents
{
    // Пример:
    
    public delegate void AccountStateHandler(string message);
    private AccountStateHandler _stateHandler;
    public event AccountStateHandler? Adding; // Объявление события до действия
    public event AccountStateHandler? Added; // Объявление события после действия

    public TheoryEvents(int sum)
    {
        Sum = sum;
    }

    private int Sum { get; set; }

    public void Put(int sum)
    {
        if (Adding != null)
        {
            Added($"На счёт добавляется {sum}");
        }
        Sum += sum;
        if (Added != null)
        {
            Added($"Пополнение счёта: {sum}");
        }
    }
}
// Практика с событиями
public class PracticeEvents
{
    public void MainMethod()
    {
        TheoryEvents theoryEvents = new TheoryEvents(100);
        
        //Подключение событий
        theoryEvents.Added += PrintToConsole;
        theoryEvents.Adding += PrintToConsole;
        // Вызов метода после подключения событий
        theoryEvents.Put(20);
    }

    private void PrintToConsole(string message)
    {
        Console.WriteLine(message);
    }
}

// События с классом-параметров
public class AccountEventArgs
{
    public string Message { get; }
    public int Sum { get; }
    
    public AccountEventArgs(int sum, string message)
    {
        Sum = sum;
        Message = message;
    }
}
// Практика с классом-параметров
// Определение сложного делегата
public delegate void AccountStateHandler(object sender, AccountEventArgs e);
public class EventPractice
{
    // Пример:
    public event AccountStateHandler Adding; 
    public event AccountStateHandler Added; 
    public EventPractice(int sum)
    {
        Sum = sum;
    }

    private int Sum { get; set; }

    public void Put(int sum)
    {
        if (Adding != null)
        {
            Added(this,new AccountEventArgs(sum,$"На счёт добавляется {sum}"));
        }
        Sum += sum;
        if (Added != null)
        {
            Added(this,new AccountEventArgs(sum,$"Пополнение счёта: {sum}"));
        }
    }
}