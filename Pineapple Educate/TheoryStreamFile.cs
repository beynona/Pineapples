using System.Text;

namespace Pineapple_Educate;

public class TheoryStreamFile
{
    public void UsingPractice()
    {
        // Конструкция using при работе с файлами позволяет:
        // 1. Открыть
        // 2. Прочитать-записать
        // 3. Закрыть
        // filePath:
        // 1. полный путь - путь от диска и до самого файла (C:\Users\Default\test.txt)
        // 2. не полный путь - в папке, где лежит exe файл программы (test.txt)
        // StreamWriter - поток для записи данных в файл
        // append:
        // 1. true - текст каждый раз будет добавляться к имеющемуся. Например, ведение логов
        // 2. false - файл каждый раз будет перезаписываться на новый
        // Encoding - кодировка сохраняемого файла
        using (var sw = new StreamWriter("filePath", true, Encoding.UTF8))
        {
            sw.Write("Hello file"); // текст в одну строку
            sw.WriteLine("Hello text in new line"); // текст на новой строке
        }

        // StreamReader - поток для чтения данных с файла
        using (var sr = new StreamReader("filePath"))
        {
            string text = sr.ReadToEnd(); // весь текст в одну строку
        }

        using (var sr = new StreamReader("filePath"))
        {
            while (!sr.EndOfStream) // Работает пока не закончатся строки в файле
            {
                Console.WriteLine(sr.ReadLine()); // Вывод на консоль построчно с файла
            }
        }
    }
}