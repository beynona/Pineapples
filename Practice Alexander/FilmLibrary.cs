using Alexander.FiLi;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace Alexander;

internal abstract class FilmLibrary
{
    private const string StartMessage =
        """
        +=========================================================================================================+
        ||                                          _____ ___  _    ___                                          ||
        ||                                         |  ___|_ _/| |  |_ _/                                         ||
        ||                                         | |_   | | | |   | |                                          ||
        ||                                         |  _|  | | | |__ | |                                          ||
        ||                                         |_|   |___\|____|___\                                         ||
        ||                                                                                                       ||
        ||                                 Вас приветствует FiLi (Film Library)!                                 ||
        ||                     Приложение, своего рода библиотека, которую Вы создаете сами.                     ||
        ||                                                                                                       ||
        +=========================================================================================================+
        """;

    internal static void StartApp()
    {
        Console.Clear();
        Console.WriteLine(StartMessage);
        Console.ReadKey();

        Movie endersGame = new Movie();
        Movie theBigShort = new Movie
        (
            "Игра на понижение",
            "2015",
            "Биография, Драма, Комедия",
            "Адам Маккей",
            """
            Кристиан Бэйл, Стив Карелл, Райан Гослинг, Брэд Питт, Мелисса Лео, Хеймиш Линклейтер, Джон Магаро,
            Рейф Сполл, Джереми Стронг, Мариса Томей
            """,
            """
            2005 год. Изучая данные ипотек по стране, чудаковатый финансовый гений и управляющий хедж-фонда Scion Capital
            Майкл Бьюрри обращает внимание на одну деталь и приходит к выводу, что американский рынок ипотечных кредитов
            может скоро лопнуть. В связи с этим он страхует около миллиарда долларов своих клиентов через кредитный дефолтный своп.
            Клиенты фонда Бьюрри волнуются из-за возможных потерь, ведь рынок ипотечных кредитов представляется весьма стабильным,
            но Майкл твёрдо стоит на своём. Вскоре эту странную активность замечают несколько финансистов на Уолл-стрит.
            Изучив данные, они осознают, что опасения Бьюрри имеют под собой веские основания. Более того, сыграв на понижение,
            можно заработать миллионы
            """
        );
        Movie theNewsroom = new Movie();
        theNewsroom.Name = "Служба новостей";
        theNewsroom.Year = "2012 - 2014";
        theNewsroom.Genre = "Драма";
        theNewsroom.Director = "Алан Пол, Грег Моттола, Энтони Хемингуэй";
        theNewsroom.Actors =
            """
            Джефф Дэниелс, Эмили Мортимер, Джон Галлахер мл., Элисон Пилл, Томас Садоски, Дев Патель, Оливия Манн,
            Сэм Уотерстон, Крис Чок, Маргарет Джадсон
            """;
        theNewsroom.Description =
            """
            Сериал рассказывает о трудовых буднях сотрудников вымышленного новостного телеканала ACN (Atlantis Cable News).
            Уилл Макэвой - популярный телеведущий вечерних новостей, но его босс Чарли Скиннер решает, что новостное шоу
            нужно обновить, особенно после скандальной речи Макэвоя во время дискуссионного клуба, в которой тот рассказал,
            почему Америка - не величайшая страна в мире, когда прежний исполнительный продюсер забирает всю свою команду
            в другой проект. Скиннер приглашает на место исполнительного продюсера опытную журналистку Маккензи Макхейл,
            которая приводит с собой несколько членов своей команды, включая Джима Харпера и его людей, с которыми делала
            новостные репортажи из Ирака. Маккензи намерена делать новое «честное» шоу без оглядки на рейтинги популярности,
            и Скиннер её в этом поддерживает. Первые выпуски проходят на удивление удачно, но когда Макэвой допускает в передачах
            резкие выпады в сторону некоторых политических партий, зрительские рейтинги начинают падать, а руководство канала -
            сомневаться в линии Скиннера и Макхейл
            """;

        Movie.Print(endersGame);
        Movie.Print(theBigShort);

        Console.WriteLine
        (
            $"""
             1. Название: {theNewsroom.Name}.
             2. Год: {theNewsroom.Year}.
             3. Жанр: {theNewsroom.Genre}.
             4. Режиссер: {theNewsroom.Director}.
             5. Актеры:
             {theNewsroom.Actors}.
             6. Описание:
             {theNewsroom.Description}.
             """
        );

        Movie newMovie = new Movie();
        Console.Write("Введите название фильма: ");
        newMovie.Name = Console.ReadLine();
        Console.Write("Введите год релиза: ");
        newMovie.Year = Console.ReadLine();
        Console.Write("Введи жанр(ы) кинокартины: ");
        newMovie.Genre = Console.ReadLine();
        Console.Write("Введите режиссера: ");
        newMovie.Director = Console.ReadLine();
        Console.Write("Введите актеров: ");
        newMovie.Actors = Console.ReadLine();
        Console.Write("Введите описание фильма: ");
        newMovie.Description = Console.ReadLine();
        Movie.Print(newMovie);

        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(endersGame, options);
        Console.WriteLine(json);
        Movie? restoredEndersGame = JsonSerializer.Deserialize<Movie>(json, options);
        if (restoredEndersGame != null) Movie.Print(restoredEndersGame);

        // StreamWriter writer = new StreamWriter("movies.json", true, System.Text.Encoding.UTF8);
        // try
        // {
        //     writer.WriteLine(json);
        // }
        // finally
        // {
        //     writer.Dispose();
        // }

        if (!Directory.Exists("fili")) Directory.CreateDirectory("./fili");
        
        using (FileStream fs = new FileStream($"fili/{theNewsroom.Name}.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, theNewsroom, options);
        }

        using (FileStream fs = new FileStream($"fili/{theNewsroom.Name}.json", FileMode.OpenOrCreate))
        {
            Movie? movie = JsonSerializer.Deserialize<Movie>(fs);
            if (movie != null) Movie.Print(movie);
        }
    }
}