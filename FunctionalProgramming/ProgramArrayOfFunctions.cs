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
            int count = 10;
            Action<int>[] action = new Action<int>[count];
            for (int i = 0; i < count; i++)
            {
                int j = i;
                action[i] = temp => temp=temp + 1;Console.WriteLine(j);
            }        
        }



      
    }
}
