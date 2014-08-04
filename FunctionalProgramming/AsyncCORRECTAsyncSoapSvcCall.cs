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

            callMultipleServicesAsync();
            //t.ContinueWith<List<bool>>(new Func<Task, List<bool>>(resultList =>
            //{
            //   Console.WriteLine("callMultipleServices has returned with {0} results", resultList.Count());
            //    Console.Read();
            //    return null;
            //}));
           // var fun = new Func<Task, List<bool>>(callback);
           // t.ContinueWith(fun);
            //Action action = new Action(() =>
            //{
            //    Console.WriteLine("callMultipleServices has returned with {0} results");
            //});
            //Task.WhenAll(new Task(action));

          //  t.ContinueWith((resultList) => { Console.WriteLine("callMultipleServices has returned with {0} results", resultList.Count()); });
            Console.Read();
        }

        public static Task callback(List<bool> resultList)
        {
            Console.WriteLine("callMultipleServices has returned with {0} results", resultList.Count());
            Console.Read();
            return null; 
        }

        public static async Task<List<bool>> callMultipleServicesAsync()
        {
            var tasks = new List<Task<bool>>();

            foreach (var user in userList)
            {
                bool response = false;
                Task<bool> t = SendMessageAsync(user);
                tasks.Add(t);
                Console.WriteLine("created callback task for user: {0} at time {1}", user, DateTime.Now.ToString("h:mm:ss tt"));
            };
            Console.WriteLine("waiting for all tasks to complete");
            bool[] responseArray = await Task.WhenAll(tasks);
            Console.WriteLine("All tasks are complete");

            return responseArray.ToList();
        }
        public static async Task<bool> SendMessageAsync(int user)
        {
            Console.WriteLine("Executing request for user {0}", user);
            Service1Client clientSoapSvc = new Service1Client();
            string s = await clientSoapSvc.GetDataAsync(user);
            Console.WriteLine("Got response {0} for user {1} at time {2}", s, user, DateTime.Now.ToString("h:mm:ss tt"));

            return true;
        }




    }
}
/*
  Result : PASSED ASYNC (8 sec for 10 requests with Async, while with sync it would have been 10*4 = 40 sec)
Executing request for user 1
created callback task for user: 1 at time 7:56:15 PM
Executing request for user 2
created callback task for user: 2 at time 7:56:15 PM
Executing request for user 3
created callback task for user: 3 at time 7:56:15 PM
Executing request for user 4
created callback task for user: 4 at time 7:56:15 PM
Executing request for user 5
created callback task for user: 5 at time 7:56:15 PM
Executing request for user 6
created callback task for user: 6 at time 7:56:15 PM
Executing request for user 7
created callback task for user: 7 at time 7:56:15 PM
Executing request for user 8
created callback task for user: 8 at time 7:56:15 PM
Executing request for user 9
created callback task for user: 9 at time 7:56:15 PM
Executing request for user 10
created callback task for user: 10 at time 7:56:15 PM
waiting for all tasks to complete
Got response You entered: 10 for user 10 at time 7:56:20 PM
Got response You entered: 1 for user 1 at time 7:56:20 PM
Got response You entered: 9 for user 9 at time 7:56:20 PM
Got response You entered: 5 for user 5 at time 7:56:20 PM
Got response You entered: 8 for user 8 at time 7:56:20 PM
Got response You entered: 2 for user 2 at time 7:56:21 PM
Got response You entered: 3 for user 3 at time 7:56:21 PM
Got response You entered: 4 for user 4 at time 7:56:22 PM
Got response You entered: 7 for user 7 at time 7:56:22 PM
Got response You entered: 6 for user 6 at time 7:56:23 PM
All tasks are complete


*/