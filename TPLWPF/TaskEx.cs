using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TPLWPF
{
    public static class TaskEx
    {



        public static YieldAsyncAwaitable TaskYieldAsync() =>new YieldAsyncAwaitable();
        
     
        
        public struct YieldAsyncAwaitable
        {
            public YieldAsyncAwaiter GetAwaiter() => new YieldAsyncAwaiter();

            public struct YieldAsyncAwaiter: INotifyCompletion
            {
                public bool IsCompleted => false;
                public void OnCompleted(Action continuation)
                {
                    ThreadPool.QueueUserWorkItem(p => continuation());
                }

                public void GetResult()
                {

                }
            }
        }

        public static DispatcherAwaiter GetAwaiter(this Dispatcher dispatcher)
        {
            return new DispatcherAwaiter(dispatcher);
        }

        public struct DispatcherAwaiter : INotifyCompletion
        {
            private Dispatcher _Dispatcher;
            public DispatcherAwaiter(Dispatcher dispatcher) => _Dispatcher = dispatcher;

            public bool IsCompleted => _Dispatcher.CheckAccess();

            public void OnCompleted(Action continuation)
            {
                _Dispatcher.Invoke(continuation);
            }
            public void GetResult() { }
        }
    }
}
