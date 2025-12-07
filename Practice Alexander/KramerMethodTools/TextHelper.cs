namespace Alexander.KramerMethodTools;

internal static class TextHelper
{
    internal const string StartMessage = """
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

    internal const string Separator = "==============================================================================+";
    internal const string QuestionNumberEquations = "Введите количество уравнений в вашей системе: ";
    internal const string InvalidInputMessage = "НЕВЕРНЫЙ ВВОД! Повторите ...";
    internal const string Path = "kramerMethodLog.txt";
    internal const string ErrorMessage = "ОШИБКА: ЛОГ-файл отсутствует.";
    internal const string EndMessage = "Bye...";

    internal const string ForInputMessageA =
        "\nВвод значений коэффициентов при неизвестных (слева-направо, сверху-вниз):";

    internal const string ForInputMessageB = "\nВвод значений свободных коэффициентов:";

    private const string SystemDefinedMessage =
        "Система уравнений совместна и определена.\nИмеет единственное решение:\n";

    private const string SystemNotDefinedMessage = "Система уравнений совместна, но не определена.\n" +
                                                   "Имеет бесчисленное множество решений.\n";

    private const string SystemNotCompatibleMessage = "Система уравнений несовместна и не имеет решений.\n";

    internal static string PreparingOutput(ref double[][] matrix,
        ref double[][] result, ref int numberEquations)
    {
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
                resultText += SystemDefinedMessage;
                for (int i = 0; i < result[2].Length; i++)
                    resultText += $"x{i + 1} = {Math.Round(result[2][i], 3, MidpointRounding.AwayFromZero)}\n";
                break;
            case 1:
                resultText += SystemNotDefinedMessage;
                break;
            case 2:
                resultText += SystemNotCompatibleMessage;
                break;
        }

        return $"Введенная матрица имеет следующий вид:{matrixText}" +
               $"Значения определителей следующие:{resultText}{TextHelper.Separator}";
    }
}