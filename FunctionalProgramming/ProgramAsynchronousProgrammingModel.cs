//http://msdn.microsoft.com/en-us/library/ms228963(v=vs.110).aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalProgramming
{
    public class Program
    {
        public IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state);
        public int EndRead(IAsyncResult asyncResult);
        public static void Main(string[] args)
        {
            
                
        }

      
    }
}
