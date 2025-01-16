namespace Pineapple_Educate;

public class TheoryArrayTypes
{
    // Одиночные массивы
    public void SingleArray()
    {
        int[] myArray = { 4, 3, 1, 4 };
        string[] myStringArray = { "first", "second" };
    }
    
    // Двумерные массивы
    public void DoubleArray()
    {
        int[,] myArray =
        {
            { 2, 4, 5, 6, 3 },
            { 3, 4, 2, 1, 4 },
            { 6, 7, 6, 5, 4 }
        };
    }
    
    // Ключевое слово params - обозначает неизвестное число элементов в массиве
    public int ParamOperator(params int[] param)
    {
        int res = 0;

        for (int i = 0; i < param.Length; i++)
        {
            res += param[i];
        }
        
        return res;
    }
    // В метод можем передать массив любого размера
    private void TestParamOperator()
    {
        int a = ParamOperator(4, 3);
        int b = ParamOperator(5, 6, 7, 8);
    }
    
    // Тип object может принимать любой тип данных
    // метод .GetType позволяет определить полученный тип данных
    private void ParamObj(params object[] param)
    {
        foreach (var obj in param)
        {
            Console.WriteLine($"{obj.GetType()} = {obj}");
        }
    }
    
    // Принцип индексации массивов
    public void IndexInSingleArray()
    {
        int[] myArray = { 4, 3, 1, 4, 7 };

        int[] newArray = myArray[..3]; // 4,3,1
        int[] newArray2 = myArray[2..]; // 1,4,7
    }
}