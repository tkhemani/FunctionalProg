using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(GetNameAsync());
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
                
        }

        static async Task<string> GetNameAsync()
        {
            await Task.Delay(1000);

            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            return await Task.Run(() => return "myName"));
        }

      
    }
}
