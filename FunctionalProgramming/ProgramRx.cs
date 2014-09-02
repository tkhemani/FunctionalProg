using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine( MyUtils.ToIdentity<int>(15).Chain(MyUtils.MyAdd).val);
            Console.WriteLine(MyUtils.ToIdentity<string>("A").Chain(x => new Identity<string>("Hi")
                    .Chain(y => new Identity<string>(y + x))).val
                );
            Console.ReadLine();
        }

    }

    public class Identity<T>
    {
        public Identity(T t)
        {
            val = t;
        }
        public T val { get; set; }

    }

    public static class MyUtils
    {
        public static Identity<T> Chain<T>(
                this Identity<T> host, Func<T, Identity<T>> op)
        {
            return op(host.val);
        }

        public static Identity<T> ToIdentity<T>(T t)
        {
            return new Identity<T>(t);
        }

        public static Func<int, Identity<int>> MyAdd = (x) => new Identity<int>(x + 10);

    }

}
