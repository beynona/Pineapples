namespace Pineapple_Educate;

// Структуры.
public class TheoryStruct
{
    // Объявление структуры
    private struct Point
    {
        public int A;
        public double B;
        public string C;
    }
    
    // Объявление пустой структуры
    private void MainFunction()
    {
        Point p = new Point();
    }

    // Ключевое слово ref
    // Позволяет изменять значимые типы по ссылке в стеке
    private void RefOp(ref Point point)
    {
        // Изменит значения структуры по ссылке в куче
        point.A = -5;
        point.B = 3;
        point.C = "data";
    }

    // Ключевое слово out
    // При объявлении out мы гарантируем, что где-то переменной будет присвоено значение
    private void OutOp(out Point point)
    {
        // Присвоит и вернёт новые значения без использования return
        point.A = -5;
        point.B = 3;
        point.C = "data";
    }
}