using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace ThreadingConsole

{
    class Program
    {
        static void Main(string[] args)
        {
            //var thread = new Thread(new ThreadStart(SecondThreadEntryPoint));
            var thread = new Thread(SecondThreadEntryPoint)
            {

                Name = "Second thread",
                Priority = ThreadPriority.Highest
              
                //Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

                //next_thread.Start(50);
            };
            //thread.Start();




            //thread.Join();

            #region Блокировка потоков на объекте
            //lock (_SyncRoot)
            //{
            //    ///.... для любых методов
            //}
            //thread.Abort() ;
            //thread.Interrupt();
            //
            //if(thread.IsAlive)
            //    if(!thread.Join(3000))
            //        thread.Interrupt();


            ////Monitor.TryEnter(); // возвращает true если можно заблокировать или false если нет, можно установить таймаут ожидания
            ////Monitor.Enter(_SyncRoot); // для Итераторов и асинхронных методов
            //try
            //{

            //}
            //finally
            //{
            //    Monitor.Exit(_SyncRoot);
            //} 
            #endregion


            var next_thread = new Thread(SecondThreadParametrizedEntryPoint)
            {
                Name = "Next thread"
            };


            var process_count = Environment.ProcessorCount;
            ThreadPool.SetMaxThreads(10, 10);
            ThreadPool.SetMinThreads(3, 3);

            for (var i = 0; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem(ThreadPoolMethod, i);
            }

            Console.WriteLine("Ожидаем завершения приложения....");
            Console.ReadLine();
        }



        /// <summary>
        /// Передача строки между потоками
        /// </summary>
        private static string _Message = "";
        private static void ThreadPoolMethod(object parameter)
        {
            var current_thread = Thread.CurrentThread;
            for(var i=0;i<100;i++)
            {
                Thread.Sleep(1000);
                lock(_SyncRoot)
                {
                    Console.Write($"id:{current_thread.ManagedThreadId}");
                    Console.Write($":{current_thread.Name}");
                    Console.WriteLine($" - {i}");
                    if (_Message.Length > 300)
                        _Message = "";
                    _Message += $"id:{current_thread.ManagedThreadId}:{i};";
                    Console.WriteLine(_Message);
                }
            }   
        }


        private static object _SyncRoot = new object();

        static void SecondThreadEntryPoint()
        {
            var currentThread = Thread.CurrentThread;

            for (var i = 0; i < 100; i++)
            {
                
                lock (_SyncRoot)
                {
                    Console.WriteLine($"id:{ currentThread.ManagedThreadId}:{i}");
                    Console.WriteLine();
                }
            }


        }
        static void SecondThreadParametrizedEntryPoint(object parameter)
        {
            var currentThread = Thread.CurrentThread;
            lock (_SyncRoot)
            {
                var count = (int)parameter;
                for (var i = 0; i < count; i++)
                {
               
                    Console.WriteLine($"id:{ currentThread.ManagedThreadId}:{i}");
                    Console.WriteLine();
                }
               
            }
        }

        [Synchronization]
        class Logger:ContextBoundObject
        {
            public void Log (string msg)
            {

            }
        }
    }
}
