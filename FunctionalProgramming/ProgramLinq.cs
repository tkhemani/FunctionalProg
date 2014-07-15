using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> BigList = new List<int>() { 1,2,3,4,5,11,12,13,14,15};
            IEnumerable<int> Smalllist = BigList.MyMethod(5);
            foreach (int v in Smalllist)
            {
                Console.WriteLine(v);
            }
        }
    }

    public static class MyExtension
    {
        public static IEnumerable<T> MyMethod<T>(this IEnumerable<T> seq, int limit)
        {
            int ctr = 0;
            foreach (T item in seq)
            {
                if (ctr < limit)
                {
                    ctr += 1;
                    yield return item;
                }
            }
        }
    }
}
