namespace Yauheni;

public class EventsPractice
{
    // public delegate void MyDelegate();
    // public event MyDelegate EventAction;

    public event Action? GoToSleep;
    public event EventHandler DoWork;

    public string Name { get; set; }
    public void OnGoToSleep(DateTime now)
    {
        if (now.Hour >= 21)
        {
            GoToSleep?.Invoke();
        }
        else
        {
            // с параметрами
            var args = EventArgs.Empty;
            
            DoWork?.Invoke(this, args);
        }
    }
}