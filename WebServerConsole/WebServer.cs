using System;
using System.IO;
using System.Net;
using System.Threading;

namespace WebServerConsole
{
    public class WebServer
    {
        private HttpListener _Listener;
        private int _Port;
        private bool _Enable;
        private readonly object SyncRoot =new object();



        public int Port => _Port;

        
        public bool Enable
        {
            get => _Enable;
            set
            {
                if (value) Start();
                else Stop();
            }
        }

        public WebServer(int port=80)
            {
            _Port = port;

            //double result;
            //var action = new Func<double, double>(x => x * x);            //Action(Start);
            //action.BeginInvoke(10,r => result=action.EndInvoke(r), null); //запуск делегата в асинхронном варианте
            //action.EndInvoke();                                           // завершает асинхронную операцию 

            }


        public void Start()
        {
            if (Enable) return;
            lock(SyncRoot)
            {
                if (Enable) return;
                //Enable = true;

                _Listener = new HttpListener();
                _Listener.Prefixes.Add($"http://*:{_Port}/");
                _Listener.IgnoreWriteExceptions = false;

                _Listener.Start();
                _Listener.BeginGetContext(Listen, _Listener);

            }
        }

        public void Stop()
        {
            if (!Enable) return;
            lock (SyncRoot)
            {
                if (!Enable) return;
                Enable = false;
                _Listener.Close();
                _Listener = null;
            }
        }

        private void Listen(IAsyncResult result)
        {
            var listener = (HttpListener)result.AsyncState;
            if (!Enable) return;

            var context = listener.EndGetContext(result);
            ThreadPool.QueueUserWorkItem(ProcessContext, context);

            listener.BeginGetContext(Listen, listener);
        }

        private void ProcessContext(object parameter)
        {
            var context = (HttpListenerContext)parameter;
            Console.WriteLine(context.Request.RawUrl);

            using (var writer = new StreamWriter(context.Response.OutputStream))
                writer.WriteLine("Hello World!");

        }


    }
}
