using Lesson5._1.Commands;
using System;
using System.Threading;
using System.Windows.Input;

namespace Lesson5._1.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public ICommand LongCommand { get; }

        public int Value { get; set; } = 13;
        private string _Title = "Длинная операция";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        public MainWindowViewModel()
        {
            LongCommand = new LambdaCommand(OnLongCommandExecuted);
        }

        private void OnLongCommandExecuted(object p)
        {
            // new Thread(LongWorkingMethod).Start();
            var action = new Action(LongWorkingMethod);
            action.Invoke(); // синхронный вызов
            var async_result=action.BeginInvoke(OnLongWorkingMethodCompleted,"параметр операции");
        }

        private void OnLongWorkingMethodCompleted(IAsyncResult result)
        {
            var parameter = (string)result.AsyncState;
            Title = parameter;
        }
        private int _Value = 42;
        private void LongWorkingMethod()
        {
            for (var i = 0; i < 50; i++)
            {
                System.Threading.Thread.Sleep(100);
            }
            Value = _Value;
            Value++;
            OnPropertyChanged(nameof(Value));
        }
    }
}
