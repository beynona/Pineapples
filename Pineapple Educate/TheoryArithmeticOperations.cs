namespace Pineapple_Educate;

public class TheoryArithmeticOperations
{
    // Арифметические операции
    private void ArithmeticOp()
    {
        // Объявление переменных
        int x = 10;
        double a = 10;
        double b = 3;
        int result = 0;
        double result2 = 0;
        
        // Операция сложения двух чисел
        result = x + 12; // 22
        // Операция вычитания двух чисел
        result = x - 6; // 4
        // операция целочисленного деления двух чисел
        result = x / 5; // 2
        result = x / 4; // 2
        result2 = a / b; // 3.33333333
        result2 = 10.0 / 4.0; // 2.5
        
        // Операция получение остатка от целочисленного деления двух чисел
        double x1 = 10.0;
        double z1 = x1 % 4.0; //результат равен 2
        
    }
    
    // Условные операции
    private void ComparisonOp()
    {
        /*
        == Равно
        != Не равно
        > Больше
        < Меньше
        >= Больше или равно
        <= Меньше или равно
        */
    }
    
    // Логические операции
    private void LogicOp()
    {
        /*
         && Сокращённое И
         || Сокращённое ИЛИ
         & И
         | ИЛИ
         ! НЕ

         Разница между сокращённым и не сокращённым:
         У сокращённых не проверяется вторая часть условия, если первая ложная
         У несокращённых будут проверяться две части условия.
        */
    }
    
    // Инкремент и декремент
    private void IncDecOp()
    {
        int a = 0;

        // Увеличить-уменьшить значение после текущей операции
        a++;
        a--;
        // Увеличить-уменьшить значение до текущей операции
        ++a;
        --a;
    }
}