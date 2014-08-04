using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public class Program
    {
        static List<string> userList = new List<string>() { "user1", "user2", "user3" };
        static List<bool> responseList = new List<bool>();

        public static void Main(string[] args)
        {

            var result = callMultipleServicesAsync();

            //Console.WriteLine("callMultipleServices has returned with {0} results on thread {1}", result.Count, Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("callMultipleServices has returned with results on thread {0}", Thread.CurrentThread.ManagedThreadId);
            Console.Read();
        }

        public static Task callback(List<bool> resultList)
        {
            Console.WriteLine("callMultipleServices has returned with {0} results", resultList.Count());
            Console.Read();
            return null;
        }

        public static async Task<Task<bool[]>> callMultipleServicesAsync()
        {
            //foreach (var user in userList)
            //{
            //    bool result = await SendMessageAsync(user);
            //        Console.WriteLine("Continue With response for user: {0} is : {1} on thread {2}", user, result, Thread.CurrentThread.ManagedThreadId);
            //        responseList.Add(result);                
            //};
            //return responseList;

            return Task.WhenAll(
        from item in userList
        select SendMessageAsync(item)); 
        }

        Func<string, Task<bool>> body = SendMessageAsync;

       public static async Task<bool> SendMessageAsync(string user)
        {
            Console.WriteLine("Executing request for user {0} on thread {1}", user, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(4000);
            Console.WriteLine("Got response for user {0} on thread {1}", user, Thread.CurrentThread.ManagedThreadId);

            return true;
        }




    }
}

/*
  Result : FAILED ASYNC 

Executing request for user user1 on thread 9
Got response for user user1 on thread 9
Executing request for user user2 on thread 9
Got response for user user2 on thread 9
Executing request for user user3 on thread 9
Got response for user user3 on thread 9
callMultipleServices has returned with results on thread 9

*/