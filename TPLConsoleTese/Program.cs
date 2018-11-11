using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TPLConsoleTese;

namespace TPLConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Parallel.Invoke(
            //    ParallelMetod,
            //    ParallelMetod,
            //    ParallelMetod,
            //    () => Console.WriteLine("Параллельная печать текста")
            //    );


            //var forParallel =  Parallel.For(5, 15, ParallelMetod);

            //while(!forParallel.IsCompleted)
            // {
            //     Thread.Sleep(10);
            // }
            // Console.WriteLine($"Завершено {forParallel.LowestBreakIteration} итераций");

            //Parallel.ForEach(Enumerable.Range(0, 11), (i, state) => Console.WriteLine(i));

            //var sum = Enumerable.Range(0, 11).Select(i => $"String #{i}")
            //    .AsParallel()
            //    .WithDegreeOfParallelism(3) // Распаралеливание на несколько потоков (3)
            //    .Select(str=>str.Length)
            //    .AsSequential() // переход в последовательное
            //    .Sum();

            //var taskParameter = "Text to Console";
            //var taskWithParameter = new Task(() => Console.WriteLine($"Task parameter is \"{taskParameter}\""));
            //taskWithParameter.Start();

            //var taskWithParameter = Task.Factory.StartNew(obj => Console.WriteLine((string)obj), taskParameter);
            //var p1 = 42;
            //var p2 = "qwe";
            //var p3 = false;

            //var TaskWithParameter = new Task(() => TestTaskMethod(p1, p2, p3));
            //taskWithParameter.Start();

            //var task = new Task(TaskMethod);
            //task.Start();
            //task.Wait();


            //var taskFunc = new Task<string>(TaskFunction);
            //taskFunc.Start();

            //var resutlt = taskFunc.Result;

            //var n = 7;

            //var parametricTask = Task.Run(() =>
            //{
            //    var result = 1;
            //    for (var i = 2; i <= n; i++)
            //        result *= i;
            //    return result;
            //});

            //Console.WriteLine(parametricTask.Result);

            AsyncTasks.Test();

            Console.ReadLine();
           
            
        }


        
        private static void ParallelMetod()
        {
            Console.WriteLine("Thread Id: {0} - started", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1500);

            Console.WriteLine("Thread Id: {0} - completed", Thread.CurrentThread.ManagedThreadId);
        }

        //private static void ParallelMetod(int i)
        //{
        //    Console.WriteLine("Thread Id: {0} - started i ={1}", Thread.CurrentThread.ManagedThreadId, i);
        //    Thread.Sleep(1500);

        //    Console.WriteLine("Thread Id: {0} - completed", Thread.CurrentThread.ManagedThreadId);
        //}

        private static void ParallelMetod(int i, ParallelLoopState state)
        {
            Console.WriteLine("Thread Id: {0} - started i ={1}", Thread.CurrentThread.ManagedThreadId, i);
            //Thread.Sleep(10);
            if (i > 10)
                state.Break();
            Thread.Sleep(1500);

            Console.WriteLine("Thread Id: {0} - completed", Thread.CurrentThread.ManagedThreadId);
        }
        
        private static void TaskMethod()
        {

        }

        private static void TaskProcedur()
        {

        }

        private static string TaskFunction()
        {
            return "Hello World";
        }

        private static void TestTaskMethod(int p1,string p2, bool p3)
        {

        }

    }
}
