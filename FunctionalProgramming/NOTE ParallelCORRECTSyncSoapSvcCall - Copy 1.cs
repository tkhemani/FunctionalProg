using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApplication6.SampleSoapSvc;

namespace FunctionalProgramming
{
    public class Program
    {
        static List<int> userList = new List<int>() { 1,2,3,4,5,6,7,8,9,10 };
        public static void Main(string[] args)
        {

            callMultipleServicesParallel();
            
            Console.Read();
        }

        public static Task callback(List<bool> resultList)
        {
            Console.WriteLine("{0}: callMultipleServices has returned with {1} results",Thread.CurrentThread.ManagedThreadId, resultList.Count());
            Console.Read();
            return null; 
        }

        public static List<string> callMultipleServicesParallel()
        {
            var responseList = new List<string>();
            Parallel.ForEach(userList, user => 
            {
                Console.WriteLine("{0}: Executing request for user {1} at time {2}", Thread.CurrentThread.ManagedThreadId, user, DateTime.Now.ToString("h:mm:ss tt"));
                Service1Client clientSoapSvc = new Service1Client();
                string s = clientSoapSvc.GetData(user);
                Console.WriteLine("{0}: Got response {1} for user {2} at time {3}", Thread.CurrentThread.ManagedThreadId, s, user, DateTime.Now.ToString("h:mm:ss tt"));
                responseList.Add(s);                
            });
            Console.WriteLine("{0}: All tasks are complete", Thread.CurrentThread.ManagedThreadId);

            return responseList;
        }       
    }
}
/*
  Result : PASSED ASYNC (8 sec for 10 requests with Async, while with sync it would have been 10*4 = 40 sec).Also, 10 threads in all.
  See that the same thread that fires the request waits for the response and then processes the response
4: Executing request for user 5 at time 8:45:36 PM
3: Executing request for user 3 at time 8:45:36 PM
1: Executing request for user 1 at time 8:45:36 PM
5: Executing request for user 7 at time 8:45:36 PM
6: Executing request for user 9 at time 8:45:36 PM
8: Executing request for user 2 at time 8:45:37 PM
9: Executing request for user 4 at time 8:45:37 PM
10: Executing request for user 6 at time 8:45:38 PM
11: Executing request for user 8 at time 8:45:38 PM
12: Executing request for user 10 at time 8:45:39 PM
3: Got response You entered: 3 for user 3 at time 8:45:41 PM
4: Got response You entered: 5 for user 5 at time 8:45:41 PM
5: Got response You entered: 7 for user 7 at time 8:45:41 PM
6: Got response You entered: 9 for user 9 at time 8:45:41 PM
1: Got response You entered: 1 for user 1 at time 8:45:41 PM
8: Got response You entered: 2 for user 2 at time 8:45:41 PM
9: Got response You entered: 4 for user 4 at time 8:45:42 PM
10: Got response You entered: 6 for user 6 at time 8:45:42 PM
11: Got response You entered: 8 for user 8 at time 8:45:43 PM
12: Got response You entered: 10 for user 10 at time 8:45:43 PM
1: All tasks are complete



*/