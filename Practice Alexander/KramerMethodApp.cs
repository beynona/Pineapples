namespace Alexander;

internal abstract class KramerMethodApp
{
    private const string StartMessage = """
                                         _____________________________________________________________________________
                                        | Данная программа предназначена для расчета решения систем линейных уравнений|
                                        |методом Крамера. Принимает в качестве аргументов коэффициенты при неизвестных|
                                        |по порядку: слева-направо, сверху-вниз; и свободные коэффициенты. Реализованы|
                                        |расчеты решений для систем из 2-х и 3-х уравнений.                           |
                                        |                      _-=||| УПРАВЛЯЮЩИЕ КОМАНДЫ |||=-_                      |
                                        +=============================================================================+
                                        |==| "exit" - выход | "doc" - вывод описания | "last" - последний результат |=|
                                        |=======| "read" - вывод всего лог-файла | "clear" - очистка лог-файла |======|
                                        +=============================================================================+
                                        | ВВОД КОМАНД производить во время запроса порядка системы. Разделитель - "," |
                                        +-----------------------------------------------------------------------------+
                                        """;

    private const string Separator = "==============================================================================+";
    private const string QuestionNumberEquations = "Введите количество уравнений в вашей системе: ";
    private const string InvalidInputMessage = "НЕВЕРНЫЙ ВВОД! Повторите ...";
    private const string Path = "kramerMethodLog.txt";
    private const string EndMessage = "Bye...";

    internal static void StartApp()
    {
        Console.WriteLine(StartMessage);
        do
        {
            Console.Write("\n" + QuestionNumberEquations);
            string? input = Console.ReadLine()?.ToLower();
            if (input is "2" or "3")
            {
                int numberEquations = Convert.ToInt32(input);
                double[][] matrix = DataGeneration(ref numberEquations);
                double[][] result = Calculation(ref matrix, ref numberEquations);
                string message = PreparingOutput(ref matrix, ref result, ref numberEquations);
                WorkingWithLogs.WriteLog(ref message, Path);
                Console.WriteLine($"\n{Separator}\n{message}");
            }
            else if (input is "doc")
                Console.WriteLine("\n" + StartMessage);
            else if (input is "last")
                WorkingWithLogs.ReadLustLog(Path, Separator);
            else if (input is "read")
            {
                WorkingWithLogs.ReadLogs(Path, Separator);
            }
            else if (input is "clear")
                WorkingWithLogs.ClearLogs(Path);
            else if (input is "exit")
            {
                Console.WriteLine("\n" + EndMessage);
                break;
            }
            else
                Console.WriteLine(InvalidInputMessage);
        } while (true);
    }

    private static double[][] DataGeneration(ref int numberEquations)
    {
        const string forInputMessageA = "\nВвод значений коэффициентов при неизвестных (слева-направо, сверху-вниз):";
        const string forInputMessageB = "\nВвод значений свободных коэффициентов:";
        double[][] matrix = new double[2][];
        matrix[0] = new double[numberEquations * numberEquations];
        matrix[1] = new double[numberEquations];
        for (int i = 0; i < matrix.Length; i++)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine(forInputMessageA);
                    break;
                case 1:
                    Console.WriteLine(forInputMessageB);
                    break;
            }

            for (int j = 0; j < matrix[i].Length; j++)
            {
                while (true)
                {
                    Console.Write($"{j + 1}: ");
                    if (double.TryParse(Console.ReadLine(), out double value))
                    {
                        matrix[i][j] = value;
                        break;
                    }

                    Console.WriteLine(InvalidInputMessage);
                }
            }
        }

        return matrix;
    }

    private static double[][] Calculation(ref double[][] matrix, ref int numberEquations)
    {
        double[] isDefined = { 0, 1, 2 };
        double[][] result = new double[3][];
        result[0] = new[] { isDefined[0] };
        result[1] = new double[numberEquations + 1];
        result[2] = new double[numberEquations];
        switch (numberEquations)
        {
            case 2:
                result[1][0] = matrix[0][0] * matrix[0][3] - matrix[0][2] * matrix[0][1];
                result[1][1] = matrix[1][0] * matrix[0][3] - matrix[1][1] * matrix[0][1];
                result[1][2] = matrix[0][0] * matrix[1][1] - matrix[0][2] * matrix[1][0];
                break;
            case 3:
                result[1][0] = matrix[0][0] * matrix[0][4] * matrix[0][8] + matrix[0][1] * matrix[0][5] * matrix[0][6] +
                               matrix[0][3] * matrix[0][7] * matrix[0][2] - matrix[0][6] * matrix[0][4] * matrix[0][2] -
                               matrix[0][3] * matrix[0][1] * matrix[0][8] - matrix[0][7] * matrix[0][5] * matrix[0][0];
                result[1][1] = matrix[1][0] * matrix[0][4] * matrix[0][8] + matrix[0][1] * matrix[0][5] * matrix[1][2] +
                               matrix[1][1] * matrix[0][7] * matrix[0][2] - matrix[1][2] * matrix[0][4] * matrix[0][2] -
                               matrix[1][1] * matrix[0][1] * matrix[0][8] - matrix[0][7] * matrix[0][5] * matrix[1][0];
                result[1][2] = matrix[0][0] * matrix[1][1] * matrix[0][8] + matrix[1][0] * matrix[0][5] * matrix[0][6] +
                               matrix[0][3] * matrix[1][2] * matrix[0][2] - matrix[0][6] * matrix[1][1] * matrix[0][2] -
                               matrix[0][3] * matrix[1][0] * matrix[0][8] - matrix[1][2] * matrix[0][5] * matrix[0][0];
                result[1][3] = matrix[0][0] * matrix[0][4] * matrix[1][2] + matrix[0][1] * matrix[1][1] * matrix[0][6] +
                               matrix[0][3] * matrix[0][7] * matrix[1][0] - matrix[0][6] * matrix[0][4] * matrix[1][0] -
                               matrix[0][3] * matrix[0][1] * matrix[1][2] - matrix[0][7] * matrix[1][1] * matrix[0][0];
                break;
        }

        if (result[1][0] != 0)
        {
            for (int i = 1; i < result[1].Length; i++)
                result[2][i - 1] = result[1][i] / result[1][0];
        }
        else
        {
            bool equalityZero = true;
            for (int i = 1; i < result[1].Length; i++)
            {
                if (result[1][i] == 0) continue;
                equalityZero = false;
                break;
            }

            result[0][0] = equalityZero ? isDefined[1] : isDefined[2];
        }

        return result;
    }

    private static string PreparingOutput(ref double[][] matrix,
        ref double[][] result, ref int numberEquations)
    {
        const string systemDefinedMessage = "Система уравнений совместна и определена.\nИмеет единственное решение:\n";
        const string systemNotDefinedMessage = "Система уравнений совместна, но не определена.\n" +
                                               "Имеет бесчисленное множество решений.\n";
        const string systemNotCompatibleMessage = "Система уравнений несовместна и не имеет решений.\n";
        string matrixText = "\n", resultText = "\n";
        for (int i = 0; i < matrix[0].Length; i++)
        {
            matrixText += $"{Math.Round(matrix[0][i], 2, MidpointRounding.AwayFromZero)}\t\t";
            if ((i + 1) % numberEquations != 0) continue;
            if ((i + 1) / numberEquations == 1)
                matrixText += $"|\t{Math.Round(matrix[1][0], 2, MidpointRounding.AwayFromZero)}\n";
            if ((i + 1) / numberEquations == 2)
                matrixText += $"|\t{Math.Round(matrix[1][1], 2, MidpointRounding.AwayFromZero)}\n";
            if ((i + 1) / numberEquations == 3)
                matrixText += $"|\t{Math.Round(matrix[1][2], 2, MidpointRounding.AwayFromZero)}\n";
        }

        for (int i = 0; i < result[1].Length; i++)
            resultText += $"D{i} = {Math.Round(result[1][i], 3, MidpointRounding.AwayFromZero)}\n";
        switch (result[0][0])
        {
            case 0:
                resultText += systemDefinedMessage;
                for (int i = 0; i < result[2].Length; i++)
                    resultText += $"x{i + 1} = {Math.Round(result[2][i], 3, MidpointRounding.AwayFromZero)}\n";
                break;
            case 1:
                resultText += systemNotDefinedMessage;
                break;
            case 2:
                resultText += systemNotCompatibleMessage;
                break;
        }

        return $"Введенная матрица имеет следующий вид:{matrixText}" +
               $"Значения определителей следующие:{resultText}{Separator}";
    }
}

internal abstract class WorkingWithLogs
{
    private const string ErrorMessage = "ОШИБКА: ЛОГ-файл отсутствует.";

    internal static void WriteLog(ref string message, string path)
    {
        StreamWriter writer = new StreamWriter(path, true, System.Text.Encoding.UTF8);
        try
        {
            writer.WriteLine(message);
        }
        finally
        {
            writer.Dispose();
        }
    }

    internal static void ReadLustLog(string path, string separator)
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
            Console.WriteLine(ErrorMessage);
        }
    }

    internal static void ReadLogs(string path, string separator)
    {
        try
        {
            StreamReader reader = new StreamReader(path, System.Text.Encoding.UTF8);
            Console.Write($"\n{separator}\n{reader.ReadToEnd()}");
            reader.Dispose();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine(ErrorMessage);
        }
    }

    internal static void ClearLogs(string path)
    {
        using StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.UTF8);
        Console.WriteLine("ЛОГ-файл очищен.");
    }
}