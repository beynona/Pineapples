using System.Text;

namespace Yauheni;

public class AsyncPractice
{
   // Объект синхронизации
   private static readonly object Locker = new object();
      
   public void AsyncPracticeMain()
   {
      Console.WriteLine("Main");
      var result = SaveFileAsync("asyncTest.txt");
      
      for (int i = 0; i < 100; i++)
      {
         Console.WriteLine($"Main {i}");
      }

      Console.WriteLine($"async result: {result.Result}");
      Console.WriteLine("End Main");
   }
   
   private async Task<bool> SaveFileAsync(string path)
   {
      var result = await Task.Run(() => SaveFile(path));
      return result;
   }
   
   private bool SaveFile(string path)
   {
      var text = "";
      Console.WriteLine("Start SaveFile");
      lock (Locker)
      {
         var rnd = new Random();
         for (int i = 0; i < 15; i++)
         {
            text += $"{i}) + {rnd.Next(0, 20)} + \r\n";
            Console.WriteLine($"save file {i}");
         }  
      }

      using (var sw = new StreamWriter(path,false,Encoding.UTF8))
      {
         sw.WriteLine(text);
      }

      Console.WriteLine("End SaveFile");
      return true;
   }
}