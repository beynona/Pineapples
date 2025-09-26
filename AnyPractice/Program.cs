namespace AnyPractice;

internal static class Program
{
    public static void Main()
    {
        ThemesPractice practice = new ThemesPractice();
        
        // null
        practice.NullPr();
        // WebClient
        practice.WebClientPr();
        // Web 
        practice.WebPr();
        // IEnumerable
        practice.EnumerablePr();
        // IEnumerator
        practice.EnumeratorPr();
        // ComparablePr
        practice.ComparablePr();
        // Hashtable
        practice.HashtablePr();
        // SortedList
        practice.SortedListPr();
        // Stack
        practice.StackPr();
        // Queue
        practice.QueuePr();
        // Parallel linq
        practice.PLinqPr();
    }
}