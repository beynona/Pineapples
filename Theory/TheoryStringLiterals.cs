using System.Text;

namespace Pineapple_Educate;

public class TheoryStringLiterals
{
    string columns = "Column 1\tColumn 2\tColumn 3";
    //Output: Column 1        Column 2        Column 3

    string rows = "Row 1\r\nRow 2\r\nRow 3";
    /* Output:
        Row 1
        Row 2
        Row 3
    */

    string title = "\"The \u00C6olean Harp\", by Samuel Taylor Coleridge";
    //Output: "The Æolean Harp", by Samuel Taylor Coleridge

    string quote = @"Her name was ""Sara.""";
    //Output: Her name was "Sara."

    string filePath = @"C:\Users\user\Documents\";
    //Output: C:\Users\user\Documents\

    private const int A = 5;
    string interpol = $"a = {A}";
    //Output: a = 5

    string s = String.Empty;
    //Output: 

    private void StringBuilderExp()
    {
        StringBuilder sb = new("Rat: the ideal pet");
        sb[0] = 'C';
        Console.WriteLine(sb.ToString());
        //Outputs Cat: the ideal pet
    }

}