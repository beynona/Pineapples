namespace Alexander.FiLi;

internal class Movie
{
    private string name;
    private int yearRelease;
    private string genre;
    private string director;
    private string actors;
    private string description;

    // public Movie(string name, int yearRelease, string genre, string director, string actors, string description)
    // {
    //     this.name = name;
    //     this.yearRelease = yearRelease;
    //     this.genre = genre;
    //     this.director = director;
    //     this.actors = actors;
    //     this.description = description;
    // }

    public string Name { get => name; set => name = value; }
    public int YearRelease { get => yearRelease; set => yearRelease = value; }
    public string Genre { get => genre; set => genre = value; }
    public string Director { get => director; set => director = value; }
    public string Actors { get => actors; set => actors = value; }
    public string Description { get => description; set => description = value; }
}