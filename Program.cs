using System;

namespace Alrecall
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try {
            TestRunner t=new TestRunner($"Alrecall.Test{args[0]}");
            
            t.Run(Console.Out);
            
            
            }
            catch(Exception e)
            {
               
               Console.WriteLine($"\nUnhandled error:\n{e.Message}\n{e.ToString()}\nStackTrace\n{e.StackTrace}");
               
               if(e.InnerException!=null)
               {
                   e=e.InnerException;
                    Console.WriteLine($"\nUnhandled error:\n{e.Message}\n{e.ToString()}");
               }
            }
        }
    }
}
