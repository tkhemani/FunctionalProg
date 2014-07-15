using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalProgramming
{
    public class Program
    {
        public delegate void DGDelegate(int a, float b);

        //bound and open
        public delegate T GenericDelegate<T1, T2, T>(T1 first, T2 second);

        public delegate T GenericDelegate<T1, T>(T1 first);

        //closed
        public static GenericDelegate<string, string> myDel1;
        
        public static GenericDelegate<string, string, string> myDel2;

        public static void Main(string[] args)
        {
            Console.WriteLine("Hi");

            Program p = new Program();
            //the following 3 are commented as our generic types are 
            //p.func2(p.bb);
            //p.func2(p.db);
            //p.func2(p.bd);
            p.func2(p.dd);
                
        }

        public delegate Base BB(Base b);
        public delegate Base BD(Derived b);
        public delegate Derived DB(Base b);
        public delegate Derived DD(Derived b);

        public BB bb = _ => { return _; };
        public BD bd = _ => { return (Base)_; };
        public DB db = _ => { return (Derived)_; };        
        public DD dd = _ => { return _; };

        public void func1(BB bb) { }

        public void func2(DD dd) { }

        public class Base {}

        public class Derived : Base { }
    }
}
