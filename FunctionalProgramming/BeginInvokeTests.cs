using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FunctionalProgramming
{
    public class Program
    {
        public delegate string MyDelegate(List<string> ls, string val);

        public static void Main(string[] args)
        {
            Console.WriteLine("{0}: Before BeginInvoke", Thread.CurrentThread.ManagedThreadId);
            MyDelegate del = new MyDelegate(DelegateMethod);
            del.BeginInvoke(new List<string>(), "Enter a Value", null, null);
              
            Console.WriteLine("{0}: After BeginInvoke", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(6000);
        }

        static string DelegateMethod(List<string> ls, string val)
        {
            ls.Add(val);
            Thread.Sleep(3000);
            Console.WriteLine("{0}: Inside BeginInvoke. Added val to list", Thread.CurrentThread.ManagedThreadId);
            return "success";
        }

      
    }
}


/*
10: Before BeginInvoke
10: After BeginInvoke
6: Inside BeginInvoke. Added val to list
*/