using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] input = {12, 14, 15, 16, 17, 112, 145, 156};
            int sum = 0;
            Parallel.ForEach(
                input,
                () => 0,
                (i, state, localSum) =>
                {
                    localSum += i;
                    Console.WriteLine("Thread={0}, n={1}, localSum={2}", Thread.CurrentThread.ManagedThreadId, i,
                        localSum);
                    return localSum;
                },
                localSum => Interlocked.Add(ref sum, localSum));

            Console.WriteLine("Sum={0}", sum);


        }
    }
}
