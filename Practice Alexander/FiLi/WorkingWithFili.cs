using static System.Text.Encoding;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Alexander.FiLi;

internal abstract class WorkingWithFili
{
    private const string NameDir = "fili";

    private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
        WriteIndented = true
    };

    internal static string[] GetListMovies()
    {
        string[] list = [];
        foreach (var file in new DirectoryInfo(NameDir).GetFiles())
        {
            Console.WriteLine(file.Name[..^5]);
            list.Append(file.Name[..^5]);
        }
        return Directory.GetFiles(NameDir, "*.json");
    }

    internal static void WriteJson(Movie movie)
    {
        string? nameFile = movie.Name;

        if (!Directory.Exists(NameDir)) Directory.CreateDirectory(NameDir);

        using StreamWriter writer = new StreamWriter($"{NameDir}/{nameFile}.json", false, UTF8);
        writer.Write(JsonSerializer.Serialize(movie, Options));
    }

    internal static Movie? ReadJson(string? nameFile)
    {
        using StreamReader reader = new StreamReader($"{NameDir}/{nameFile}.json", UTF8);
        return JsonSerializer.Deserialize<Movie>(reader.ReadToEnd());
    }
}