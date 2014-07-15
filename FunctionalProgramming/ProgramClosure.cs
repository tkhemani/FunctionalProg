using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalProgramming
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program program = new Program();
            //closures allow function chaining, IIFE
            var result = program.myFunc()(12);
        }

        Func<int, int> myFunc()
        {
            //c# creates a class that has i as a prop, so its shared by all instances 

            int i = 10;
            Func<int, int> rFunc = i1 => i1 + i;

            return rFunc;
        }


    }
}
