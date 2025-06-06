namespace Pineapple_Educate;

// Делегаты.
// Делегаты - указатели на методы.
// Ключевое слово delegate
public class TheoryDelegate
{
    // Данному делегату соответствуют все методы, которые принимают 1 строковый параметр и ничего не возвращают
    delegate void Message(string message);
    // Данному делегату соответствуют все методы, которые принимают 2 int параметра и возвращают тип int
    delegate int Operation(int x, int y);

    // ТЕСТ
    public void TestDelegates()
    {
        Message message = ConsoleDisplay; // создание переменной делегата
        message.Invoke("hello"); // вызов делегата
    }
    // Данный метод соответствует делегату Message
    private void ConsoleDisplay(string message)
    {
        Console.WriteLine(message);
    }
}