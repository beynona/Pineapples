namespace Pineapple_Educate;

// Циклы и тернарный оператор.
public class TheoryBranching
{
    // ОПЕРАТОР ВЕТВЛЕНИЯ if-else
    private void IfElseBranch(bool trust)
    {
        if (trust)
        {
            // Выполняется, если trust = true
        }
        else
        {
            // Выполняется, если trust = false
        }
    }
    
    // ОПЕРАТОР ВЕТВЛЕНИЯ while
    // Цикл выполняет до тех пор, пока trust = true
    private void WhileBranch(bool trust)
    {
        while (trust)
        {
            // code
        }
    }
    
    // ОПЕРАТОР ВЕТВЛЕНИЯ do-while
    // Цикл выполнится 1 раз по умолчанию
    // и потом будет выполняться до тех пор, пока trust = true
    private void DoWhileBranch(bool trust = false)
    {
        do
        {
            // code
        } while (trust);
    }
    
    // ЦИКЛ for
    // for ([действия_до_выполнения_цикла]; [условие]; [действия_после_выполнения])
    private void ForCycles(int col)
    {
        for (int i = 0; i < col; i++)
        {
            Console.WriteLine($"Hello {i}");
        }
    }
    
    // КЛЮЧЕВЫЕ СЛОВА break-continue
    private void BreakAndContinueBranch(int col = 5)
    {
        for (int i = 0; i < col; i++)
        {
            Console.WriteLine($"Hello {i}");

            if (i == 2)
            {
                // Пропустить итерацию и перейти к следующей
                continue;
            }

            if (i >= 5)
            {
                // Прерывает цикл
                break;
            }
        }
    }
    
    // Тернарный оператор
    private int TernaryOp(int a, int b, bool enable)
    {
        // [условие] ? [если условие true] : [если условие false]
        return enable ? a + b : 0;
    }
    // Пример тернарного оператора
    private void TernaryOpExample(int a, string b)
    {
        string access = a > 0 && b != "User" ? "Admin" : "Operator";
    }
}