using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPLConsoleTese
{
    public class AsyncTasks
    {
        public static void Test ()
        {
            var task = TestAsync();
            task.ContinueWith(t => Console.WriteLine(t.Result));
            Console.WriteLine($"Текущая задача {Task.CurrentId},thread id {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Задача {task.Id} запущена");

        }


        private static async Task<string> TestAsync()
        {
           await Task.Delay(3000);
            Console.WriteLine($"текущая задача {Task.CurrentId},thread id {Thread.CurrentThread.ManagedThreadId}");
            return "Hello World";
        }

    }
}
1 33