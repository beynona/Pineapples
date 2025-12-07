namespace Alexander.KramerMethodTools;

internal static class LogManager
{
    internal static void WriteLog(ref string message, string path)
    {
        using StreamWriter writer = new StreamWriter(path, true, System.Text.Encoding.UTF8);
        writer.WriteLine(message);
    }

    internal static void ReadLastLog(string path, string separator)
    {
        try
        {
            string[] lines = File.ReadAllLines(path, System.Text.Encoding.UTF8);
            int startOutputIndex = 0;
            int lastSeparatorIndex = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != separator) continue;
                startOutputIndex = lastSeparatorIndex + 1;
                lastSeparatorIndex = i;
            }

            Console.WriteLine($"\n{separator}");
            if (startOutputIndex is 0 or 1)
            {
                foreach (string line in lines) Console.WriteLine(line);
            }
            else
            {
                for (int i = startOutputIndex; i < lines.Length; i++) Console.WriteLine(lines[i]);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine(TextHelper.ErrorMessage);
        }
    }

    internal static void ReadLogs(string path, string separator)
    {
        try
        {
            using StreamReader reader = new StreamReader(path, System.Text.Encoding.UTF8);
            Console.Write($"\n{separator}\n{reader.ReadToEnd()}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine(TextHelper.ErrorMessage);
        }
    }

    internal static void ClearLogs(string path)
    {
        using StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.UTF8);
        Console.WriteLine("ЛОГ-файл очищен.");
    }
}