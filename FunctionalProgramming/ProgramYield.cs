﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyList myList = new MyList();

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }

    public class MyList : IEnumerable<int>
    {

        public IEnumerable<int> Sequence()
        {
            int i = 0;
            for (i = 0; i < 10; i++)
            {
                yield return i;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<int>).GetEnumerator();
        }
    }
}
