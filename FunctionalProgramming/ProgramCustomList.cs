using System;
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
        private List<int> _list = new List<int>();

        public MyList()
        {
            _list.AddRange(new [] {1,2,3,4,5});           
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<int>).GetEnumerator();
        }
    }
}
