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
        public static async void Test ()
        {
            var task = TestAsync();
            task.ContinueWith(t => Console.WriteLine(t.Result));
            Console.WriteLine($"Текущая задача {Task.CurrentId},thread id {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Задача {task.Id} запущена");

            var data = Enumerable.Range(0, 11).Select(i => $"String #{i}");

            var tasks = data.Select(d => Task.Run(() => { Console.WriteLine(d); }));

            //await Task.WhenAll(tasks);
            await Task.WhenAny(tasks);

            //await Task.WhenAll(
            //    Task.Run(() => { /* Длительная задача № 1*/}),
            //    Task.Run(() => { /* Длительная задача № 2*/}),
            //    Task.Run(() => { /* Длительная задача № 3*/}),
            //    Task.Run(() => { /* Длительная задача № 4*/})
            //    );
        }


        private static async Task<string> TestAsync()
        {
           await Task.Delay(3000);
            Console.WriteLine($"текущая задача {Task.CurrentId},thread id {Thread.CurrentThread.ManagedThreadId}");
            return "Hello World";
        }

    }
}
