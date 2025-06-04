namespace Yauheni;

public class StreamPractice
{
    public void WriteAndReadFromFile()
    {
        // Запись в файл
        using (var sw = new StreamWriter("test.txt"))
        {
            sw.WriteLine("Hello from file");
        }
        
        // Чтение из файла
        using (var sr = new StreamReader("test.txt"))
        {
            string text = sr.ReadToEnd();
            Console.WriteLine(text);
        }
    }
}