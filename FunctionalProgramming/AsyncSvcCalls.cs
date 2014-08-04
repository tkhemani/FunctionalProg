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

            Task t = callMultipleServicesAsync();
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
            foreach (var user in userList)
            {
                bool response = false;
                response = await SendMessageAsync(user);
                Console.WriteLine("response for user: {0} is : {1}", user, response);
                responseList.Add(response);

            };
            return responseList;
        }
        public static async Task<bool> SendMessageAsync(string user)
        {
            Console.WriteLine("Executing request for user {0}", user);
            await Task.Delay(4000);
            Console.WriteLine("Got response for user {0}", user);

            return true;
        }




    }
}
/*
  Result : FAILED ASYNC 
 

Executing request for user user1
Got response for user user1
response for user: user1 is : True
Executing request for user user2
Got response for user user2
response for user: user2 is : True
Executing request for user user3
Got response for user user3
response for user: user3 is : True

*/