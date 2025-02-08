namespace Alexander;

internal abstract class KramerMethodApp
{
    private const string StartMessage = "  Данная программа предназначена для расчета решения систем линейных уравнений \n" +
                                        " методом Крамера. Принимает в качестве аргументов коэффициенты при неизвестных \n" +
                                        " по порядку: слева-направо, сверху-вниз; и свободные коэффициенты. Реализованы \n" +
                                        " расчеты решений для систем из 2-х и 3-х уравнений.                            \n" +
                                        "                       _-=||| УПРАВЛЯЮЩИЕ КОМАНДЫ |||=-_                       \n" +
                                        "+=============================================================================+\n" +
                                        "|\"exit\" - выход | \"doc\" - вывод описания | \"last result\" - последний результат|\n" +
                                        "|=======| \"read\" - вывод всего лог-файла | \"clear\" - очистка лог-файла |======|\n" +
                                        "+=============================================================================+\n" +
                                        "           ВВОД КОМАНД производить во время запроса порядка системы.           ";
    private const string QuestionNumberEquations = "Введите количество уравнений в вашей системе: ";
    private const string InvalidInputMessage = "НЕВЕРНЫЙ ВВОД! Повторите ...";
    private const string ForInputMessageA = "\nВвод значений коэффициентов при неизвестных (слева-направо, сверху-вниз):";
    private const string ForInputMessageB = "\nВвод значений свободных коэффициентов:";
    private const string SystemDefinedMessage = "Система уравнений совместна и определена.\nИмеет единственное решение:";
    private const string SystemNotDefinedMessage = "Система уравнений совместна, но не определена.\nИмеет бесчисленное множество решений.";
    private const string SystemNotCompatibleMessage = "Система уравнений несовместна и не имеет решений.";
    private const string EndMessage = "Bye...";
    
    public static void StartApp()
    {
        Console.WriteLine(StartMessage);
        do
        {
            Console.Write("\n" + QuestionNumberEquations);
            string? input = Console.ReadLine();
            if (input is "2" or "3")
            {
                double[][] matrix = DataGeneration(int.Parse(input));
                double[][] result = Calculation(matrix, input);
                Console.WriteLine();
                foreach (double[] row in result)
                {
                    foreach (double value in row)
                    {
                        Console.Write(value + "\t");
                    }
                    Console.WriteLine();
                }
            }
            else if (input is "exit")
            {
                Console.WriteLine("\n" + EndMessage);
                break;
            }
            else if (input is "doc")
                Console.WriteLine("\n" + StartMessage);
            else
                Console.WriteLine(InvalidInputMessage);
        } while (true);
    }

    private static double[][] DataGeneration(int numberEquations)
    {
        double[][] matrix = new double[2][];
        matrix[0] = new double[numberEquations * numberEquations];
        matrix[1] = new double[numberEquations];
        for (int i = 0; i < matrix.Length; i++)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine(ForInputMessageA);
                    break;
                case 1:
                    Console.WriteLine(ForInputMessageB);
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

    private static double[][] Calculation(double[][] matrix, string numberEquations)
    {
        double[] isDefined = [0, 1, 2];
        double[][] result = new double[3][];
        result[0] = [isDefined[0]];
        switch (numberEquations)
        {
            case "2":
                double determinant = matrix[0][0] * matrix[0][3] - matrix[0][2] * matrix[0][1];
                double determinant1 = matrix[1][0] * matrix[0][3] - matrix[1][1] * matrix[0][1];
                double determinant2 = matrix[0][0] * matrix[1][1] - matrix[0][2] * matrix[1][0];
                result[1] = [determinant, determinant1, determinant2];
                if (determinant == 0)
                {
                    result[0] = [isDefined[2]];
                    if (determinant1 == 0 && determinant2 == 0)
                    {
                        result[0] = [isDefined[1]];
                    }
                }
                result[2] = [determinant1 / determinant, determinant2 / determinant];
                break;
            case "3":
                break;
        }
        return result;
    }
}