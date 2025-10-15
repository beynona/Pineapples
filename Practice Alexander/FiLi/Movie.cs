namespace Alexander.FiLi;

internal class Movie
{
    // public Movie(string name, int yearRelease, string genre, string director, string actors, string description)
    // {
    //     this.name = name;
    //     this.yearRelease = yearRelease;
    //     this.genre = genre;
    //     this.director = director;
    //     this.actors = actors;
    //     this.description = description;
    // }

    internal string Name { get; set; } = "Игра Эндера";
    internal int YearRelease { get; set; } = 2013;
    internal string Genre { get; set; } = "фантастика, боевик, приключения, фэнтези";
    internal string Director { get; set; } = "Гевин Худ";

    internal string Actors { get; set; } =
        """
        Эйса Баттерфилд, Харрисон Форд, Бен Кингсли, Виола Дэвис, Хейли Стайнфелд, Эбигейл Бреслин, Арамис Найт,
        Сурадж Партха, Мойзес Ариас, Кайлин Рамбо
        """;

    internal string Description { get; set; } =
        """
        Действие происходит в 2135 году. Человечество пережило два вторжения инопланетной расы «жукеров», лишь чудом уцелев, и готовится к очередному вторжению.
        Для поиска пилотов и военачальников, способных принести Земле победу, создаётся военная школа, в которую отправляют самых талантливых детей.
        Среди этих детей Эндрю (Эндер) Виггин, будущий полководец Международного флота Земли и единственная надежда человечества на спасение.
        """;
}