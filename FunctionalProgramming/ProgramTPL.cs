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
            Parallel.Invoke(() => DoThis(), () => DoThat());
            Console.WriteLine("Main " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            Console.ReadLine();
        }

        static void DoThis()
        {
            Console.WriteLine("This " + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

        static void DoThat()
        {
            Console.WriteLine("That " + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }
          
    }
}
