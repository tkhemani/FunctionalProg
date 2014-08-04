//http://www.codeproject.com/Articles/575713/What-is-the-use-of-csharp-Yield-keyword 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalProgramming
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] test = { 1, 2, 3 };

            foreach (var item in test.RunningTotal())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
    public static class ExtensionMethod
    {
        public static IEnumerable RunningTotal(this IEnumerable collection)
        {
            int sum = 0;
            foreach (int item in collection)
            {
                yield return sum = sum + item;
            }
        }
    }
}
