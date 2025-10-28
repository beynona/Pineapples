using static System.Text.Encoding;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Alexander.FiLi;

internal static class FileManager
{
    internal static void StartInitLibrary()
    {
        //todo - дублирование кода
        if (!Directory.Exists(TextExtension.NameDir)) FirstLibraryInit.StartInit();
    }

    internal static string[] GetListMovies()
    {
        var listFiles = new DirectoryInfo(TextExtension.NameDir).GetFiles();
        string[] list = new string[listFiles.Length];
        for (int i = 0; i < listFiles.Length; i++)
        {
            list[i] = listFiles[i].Name[..^5];
        }

        return list;
    }

    internal static void WriteJson(Movie movie)
    {
        string? nameFile = movie.Name?.ToLower();
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
        //todo - дублирование кода
        if (!Directory.Exists(TextExtension.NameDir)) Directory.CreateDirectory(TextExtension.NameDir);

        // todo - а если nameFile будет null?
        using StreamWriter writer = new StreamWriter($"{TextExtension.NameDir}/{nameFile}.json", false, UTF8);
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
}