using static System.Text.Encoding;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Alexander.FiLi;

internal static class FileManager
{
    internal static void InitBaseLibrary()
    {
        if (!DirIsExists()) BaseLibrary.StartInit();
    }

    internal static string[] GetListMovies()
    {
        FileInfo[] files = new DirectoryInfo(TextExtension.NameDir).GetFiles();
        string[] movies = new string[files.Length];
        
        for (int i = 0; i < files.Length; i++)
        {
            movies[i] = files[i].Name[..^5];
        }

        return movies;
    }

    internal static void WriteJson(Movie? movie)
    {
        if (string.IsNullOrEmpty(movie?.Name))
        {
            return;
        }
        
        string fileName = movie.Name.ToLower();
        
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
        
        if (!DirIsExists()) Directory.CreateDirectory(TextExtension.NameDir);

        using StreamWriter writer = new StreamWriter($"{TextExtension.NameDir}/{fileName}.json", false, UTF8);
        writer.Write(JsonSerializer.Serialize(movie, options));
    }

    internal static Movie? ReadJson(string? nameFile)
    {
        try
        {
            using StreamReader reader = new StreamReader($"{TextExtension.NameDir}/{nameFile}.json", UTF8);
            return JsonSerializer.Deserialize<Movie>(reader.ReadToEnd());
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("ФАЙЛ НЕ НАЙДЕН!");
        }

        return null;
    }

    private static bool DirIsExists()
    {
        return Directory.Exists(TextExtension.NameDir);
    }
}