namespace Pineapple_Educate;

// Generic обобщения.
// При формировании класса мы указываем обобщённый параметр <T>,
// чтобы потом при создании экземпляра данного класса мы сами выбрали нужный тип данных
public class TheoryGenerics
{
    public void TestGenericMain()
    {
        // Как мы видим id меняет свой тип данных на заданный
        Account<string> misha = new Account<string>("123332", 23);
        Account<int> gleb = new Account<int>(312312, 213123);
    }
    
    class Account<T>
    {
        public T Id;
        public int Sum;

        public Account(T id, int sum)
        {
            Id = id;
            Sum = sum;
        }
    }
}