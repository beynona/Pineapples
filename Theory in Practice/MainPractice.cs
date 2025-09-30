namespace AnyPractice;

internal static class MainPractice
{
    public static void Main()
    {
        ThemesPractice practice = new ThemesPractice();
        
        // null типы
        practice.NullPr();
        // Работа с данными в интернете - WebClient
        practice.WebClientPr();
        // Работа с данными в интернете - Web 
        practice.WebPr();
        // Интерфейс IEnumerable
        practice.EnumerablePr();
        // Интерфейс IEnumerator
        practice.EnumeratorPr();
        // Интерфейс IComparable
        practice.ComparablePr();
        // Структура хранения данных - Hashtable
        practice.HashtablePr();
        // Структура хранения данных - SortedList
        practice.SortedListPr();
        // Структура хранения данных - Stack
        practice.StackPr();
        // Структура хранения данных - Queue
        practice.QueuePr();
        // Выполнение в нескольких потоках - ParallelQuery
        practice.PLinqPr();
        // Перегрузки оператора +, использованем обобщённых типов generic T
        ProductHelpers.CalculateCalories();
        // Использование интерфейсов
        CarHelpers.AnyCarMove();
    }
}