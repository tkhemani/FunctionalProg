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
            var result = callMultipleServices();
            Console.WriteLine("callMultipleServices has returned with {0} results on thread {1}", result.Count, Thread.CurrentThread.ManagedThreadId);
            Console.Read();
        }

        public static List<bool> callMultipleServices()
        {
            Parallel.ForEach(userList, user =>
           {
               bool response = false;
               response = SendMessage(user);
               Console.WriteLine("response for user: {0} is : {1} on thread {2}", user, response, Thread.CurrentThread.ManagedThreadId);
               responseList.Add(response);

           });
            return responseList;
        }
        public static bool SendMessage(string user)
        {
            Console.WriteLine("Executing request for user {0} on thread {1}", user, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            Console.WriteLine("Got response for user {0} on thread {1}", user, Thread.CurrentThread.ManagedThreadId);
            return true;
        }




    }
}


/*
  Result : PASSED ASYNC BUT ON PARALLEL THREADS ALL WAITING FROM RESPONSE 
 
Executing request for user user1 on thread 1
Executing request for user user2 on thread 3
Executing request for user user3 on thread 5
Got response for user user1 on thread 1
response for user: user1 is : True on thread 1
Got response for user user3 on thread 5
response for user: user3 is : True on thread 5
Got response for user user2 on thread 3
response for user: user2 is : True on thread 3
callMultipleServices has returned with 3 results on thread 1

*/