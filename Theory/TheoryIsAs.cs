namespace Pineapple_Educate;

public class TheoryIsAs
{
    // is - возвращает true, если тип соответсвует нашему типу
    // as - если тип соответствует нашему типу присваиваем переменной наше значение

    private void IsAsPractice()
    {
        object p1 = new Place() { X = 5 };
        
        // Является ли p1 объектом класса Place
        // true - если является, false - если не является
        var res1 = p1 is Place;

        // Если p1 ялвяется объектом Place, то сразу преобразуем в нужный тип.
        // Если преобразовать не удалось, то возвращаем null.
        var res2 = p1 as Place;
    }
}

class Place
{
    public int X { get; set; }
}