﻿using System;
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
        static List<int> userList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static void Main(string[] args)
        {

            callMultipleServicesAsync();

            Console.Read();
        }

        public static Task callback(List<string> resultList)
        {
            Console.WriteLine("{0}: callMultipleServices has returned with {1} results", Thread.CurrentThread.ManagedThreadId, resultList.Count());
            Console.Read();
            return null;
        }

        public static async Task<List<string>> callMultipleServicesAsync()
        {
            var tasks = new List<Task<string>>();

            foreach (var user in userList)
            {
                Task<string> t = SendMessageAsync(user);
                tasks.Add(t);
                Console.WriteLine("{0}: created callback task for user: {1} at time {2}", Thread.CurrentThread.ManagedThreadId, user, DateTime.Now.ToString("h:mm:ss tt"));
            };
            Console.WriteLine("{0}: waiting for all tasks to complete", Thread.CurrentThread.ManagedThreadId);
            string[] responseArray = await Task.WhenAll(tasks);
            Console.WriteLine("{0}: All tasks are complete", Thread.CurrentThread.ManagedThreadId);

            return responseArray.ToList();
        }
        public static async Task<string> SendMessageAsync(int user)
        {
            Console.WriteLine("{0}: Executing request for user {1} at time {2}", Thread.CurrentThread.ManagedThreadId, user, DateTime.Now.ToString("h:mm:ss tt"));
            Service1Client clientSoapSvc = new Service1Client();
            string s = await clientSoapSvc.GetDataAsync(user);
            Console.WriteLine("{0}: Got response {1} for user {2} at time {3}", Thread.CurrentThread.ManagedThreadId, s, user, DateTime.Now.ToString("h:mm:ss tt"));
            return s;
        }




    }
}
/*
  Result : PASSED ASYNC (8 sec for 10 requests with Async, while with sync it would have been 10*4 = 40 sec). Also, 5 threads in all
1: Executing request for user 1
1: created callback task for user: 1 at time 8:32:45 PM
1: Executing request for user 2
1: created callback task for user: 2 at time 8:32:45 PM
1: Executing request for user 3
1: created callback task for user: 3 at time 8:32:45 PM
1: Executing request for user 4
1: created callback task for user: 4 at time 8:32:45 PM
1: Executing request for user 5
1: created callback task for user: 5 at time 8:32:45 PM
1: Executing request for user 6
1: created callback task for user: 6 at time 8:32:45 PM
1: Executing request for user 7
1: created callback task for user: 7 at time 8:32:45 PM
1: Executing request for user 8
1: created callback task for user: 8 at time 8:32:45 PM
1: Executing request for user 9
1: created callback task for user: 9 at time 8:32:45 PM
1: Executing request for user 10
1: created callback task for user: 10 at time 8:32:45 PM
1: waiting for all tasks to complete
6: Got response You entered: 2 for user 2 at time 8:32:49 PM
5: Got response You entered: 4 for user 4 at time 8:32:49 PM
7: Got response You entered: 1 for user 1 at time 8:32:49 PM
9: Got response You entered: 3 for user 3 at time 8:32:49 PM
9: Got response You entered: 5 for user 5 at time 8:32:50 PM
9: Got response You entered: 6 for user 6 at time 8:32:50 PM
9: Got response You entered: 7 for user 7 at time 8:32:51 PM
9: Got response You entered: 8 for user 8 at time 8:32:51 PM
9: Got response You entered: 9 for user 9 at time 8:32:52 PM
9: Got response You entered: 10 for user 10 at time 8:32:53 PM
9: All tasks are complete


*/