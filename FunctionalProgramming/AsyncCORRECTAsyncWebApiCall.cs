using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public class Program
    {
        static List<string> userList = new List<string>() { "user1", "user2", "user3", "user4", "user5", "user6", "user7", "user1", "user2", "user3", "user4", "user5", "user6", "user7" };
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
        public static async Task<bool> SendMessageAsync(string user)
        {
            Console.WriteLine("Executing request for user {0}", user);
            //await Task.Delay(4000);
            var client = new HttpClient();
            await client.GetAsync("http://miapgkhematarwd.msad.ms.com/RefreshLiveConfig/api/WebApi");
            Console.WriteLine("Got response for user {0} at time {1}", user, DateTime.Now.ToString("h:mm:ss tt"));

            return true;
        }




    }
}
/*
  Result : PASSED ASYNC 
 
Executing request for user user1
created callback task for user: user1 at time 6:47:51 PM
Executing request for user user2
created callback task for user: user2 at time 6:47:51 PM
Executing request for user user3
created callback task for user: user3 at time 6:47:51 PM
Executing request for user user4
created callback task for user: user4 at time 6:47:51 PM
Executing request for user user5
created callback task for user: user5 at time 6:47:51 PM
Executing request for user user6
created callback task for user: user6 at time 6:47:51 PM
Executing request for user user7
created callback task for user: user7 at time 6:47:51 PM
Executing request for user user1
created callback task for user: user1 at time 6:47:51 PM
Executing request for user user2
created callback task for user: user2 at time 6:47:51 PM
Executing request for user user3
created callback task for user: user3 at time 6:47:51 PM
Executing request for user user4
created callback task for user: user4 at time 6:47:51 PM
Executing request for user user5
created callback task for user: user5 at time 6:47:51 PM
Executing request for user user6
created callback task for user: user6 at time 6:47:51 PM
Executing request for user user7
created callback task for user: user7 at time 6:47:51 PM
waiting for all tasks to complete
Got response for user user1 at time 6:47:56 PM
Got response for user user1 at time 6:48:01 PM
Got response for user user5 at time 6:48:01 PM
Got response for user user4 at time 6:48:01 PM
Got response for user user7 at time 6:48:01 PM
Got response for user user3 at time 6:48:01 PM
Got response for user user2 at time 6:48:01 PM
Got response for user user2 at time 6:48:01 PM
Got response for user user3 at time 6:48:02 PM
Got response for user user6 at time 6:48:03 PM
Got response for user user5 at time 6:48:04 PM
Got response for user user4 at time 6:48:06 PM
Got response for user user7 at time 6:48:06 PM
Got response for user user6 at time 6:48:06 PM
All tasks are complete


*/