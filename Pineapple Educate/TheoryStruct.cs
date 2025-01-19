namespace Pineapple_Educate;

public class TheoryStruct
{
    // Объявление структуры
    private struct Point
    {
        public int a;
        public double b;
        public string c;
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
        point.a = -5;
        point.b = 3;
        point.c = "data";
    }

    // Ключевое слово out
    // При объявлении out мы гарантируем, что где-то переменной будет присвоено значение
    private void OutOp(out Point point)
    {
        // Присвоит и вернёт новые значения без использования return
        point.a = -5;
        point.b = 3;
        point.c = "data";
    }
}