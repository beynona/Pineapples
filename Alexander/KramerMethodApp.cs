namespace Alexander;

internal abstract class KramerMethodApp
{
    private const string StartMessage = "  Данная программа предназначена для расчета решения систем линейных уравнений \n" +
                                        " методом Крамера. Принимает в качестве аргументов коэффициенты при неизвестных \n" +
                                        " по порядку: слева-направо, сверху-вниз; и свободные коэффициенты. Реализованы \n" +
                                        " расчеты решений для систем из 2-х и 3-х уравнений.                            \n" +
                                        "                       _-=||| УПРАВЛЯЮЩИЕ КОМАНДЫ |||=-_                       \n" +
                                        "+=============================================================================+\n" +
                                        "|\"ВЫХОД\" - выход | \"ДОК\" - вывод описания | \"..........\" - последний результат|\n" +
                                        "|=======| \"....\" - вывод всего лог-файла | \".....\" - очистка лог-файла |======|\n" +
                                        "+=============================================================================+\n" +
                                        "           ВВОД КОМАНД производить во время запроса порядка системы.           ";
    private const string QuestionNumberEquations = "Введите количество уравнений в вашей системе: ";
    private const string InvalidInputMessage = "НЕВЕРНЫЙ ВВОД! Повторите ...";
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
                double[][] matrix = DataGeneration(numberEquations);
                double[][] result = Calculation(matrix, numberEquations);
                PrintResult(result, matrix, numberEquations);
            }
            else if (input is "выход")
            {
                Console.WriteLine("\n" + EndMessage);
                break;
            }
            else if (input is "док")
                Console.WriteLine("\n" + StartMessage);
            else
                Console.WriteLine(InvalidInputMessage);
        } while (true);
    }

    private static double[][] DataGeneration(int numberEquations)
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
                    Console.Write($"{j+1}: ");
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

    private static double[][] Calculation(double[][] matrix, int numberEquations)
    {
        double[] isDefined = [0, 1, 2];
        double[][] result = new double[3][];
        result[0] = [isDefined[0]];
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
                if (result[1][i] != 0) equalityZero = false;
                result[2][i - 1] = double.PositiveInfinity;
            }
            result[0][0] = equalityZero ? isDefined[1] : isDefined[2];
        }
        return result;
    }

    private static void PrintResult(double[][] result, double[][] matrix, int numberEquations)
    {
        const string systemDefinedMessage = " Система уравнений совместна и определена.\n Имеет единственное решение:";
        const string systemNotDefinedMessage = " Система уравнений совместна, но не определена.\n Имеет бесчисленное множество решений.";
        const string systemNotCompatibleMessage = " Система уравнений несовместна и не имеет решений.";
        const string separator = "+=============================================================================+";
        Console.WriteLine($"\n{separator}\n Введенная матрица имеет следующий вид:");
        for (int i = 0; i < matrix[0].Length; i++)
        {
            Console.Write(" {0}\t\t", Math.Round(matrix[0][i], 2, MidpointRounding.AwayFromZero));
            if ((i + 1) % numberEquations != 0) continue;
            Console.Write("|\t");
            if ((i + 1) / numberEquations == 1) Console.WriteLine(Math.Round(matrix[1][0], 2, MidpointRounding.AwayFromZero));
            if ((i + 1) / numberEquations == 2) Console.WriteLine(Math.Round(matrix[1][1], 2, MidpointRounding.AwayFromZero));
            if ((i + 1) / numberEquations == 3) Console.WriteLine(Math.Round(matrix[1][2], 2, MidpointRounding.AwayFromZero));
        }
        Console.WriteLine(" Значения определителей следующие:");
        for (int i = 0; i < result[1].Length; i++)
            Console.WriteLine($" D{i} = {Math.Round(result[1][i], 3, MidpointRounding.AwayFromZero)}");
        switch (result[0][0])
        {
            case 0:
                Console.WriteLine(systemDefinedMessage);
                for (int i = 0; i < result[2].Length; i++)
                    Console.WriteLine($" x{i+1} = {Math.Round(result[2][i], 3, MidpointRounding.AwayFromZero)}");
                break;
            case 1:
                Console.WriteLine(systemNotDefinedMessage);
                break;
            case 2:
                Console.WriteLine(systemNotCompatibleMessage);
                break;
        }
        Console.WriteLine(separator);
    }
}