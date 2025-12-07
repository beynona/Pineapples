namespace Alexander.KramerMethodTools;

internal static class DataManager
{
    internal static double[][] DataGeneration(ref int numberEquations)
    {
        double[][] matrix = new double[2][];
        matrix[0] = new double[(int)Math.Pow(numberEquations, 2)];
        matrix[1] = new double[numberEquations];
        for (int i = 0; i < matrix.Length; i++)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine(TextHelper.ForInputMessageA);
                    break;
                case 1:
                    Console.WriteLine(TextHelper.ForInputMessageB);
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

                    Console.WriteLine(TextHelper.InvalidInputMessage);
                }
            }
        }

        return matrix;
    }

    internal static double[][] Calculation(ref double[][] matrix, ref int numberEquations)
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
}