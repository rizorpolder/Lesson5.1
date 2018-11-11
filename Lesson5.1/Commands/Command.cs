using System;
using System.Windows.Input;

namespace Lesson5._1.Commands
{
     class LambdaCommand:ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        
        private readonly Action<object> _ExecuteAction;

        private readonly Func<object,bool> _CanExecute;

        public LambdaCommand(Action <object> ExecuteAction, Func<object,bool> CanExecuteFunc = null)
        {
            _ExecuteAction = ExecuteAction;
            _CanExecute = CanExecuteFunc;
        }

        public bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;
       

        public void Execute(object parameter) => _ExecuteAction(parameter);
        
    }
    class LongWoringCommand:LambdaCommand
    {
        private static void OnCommandExecute(object parameter)
        {

        }
        public LongWoringCommand():base(OnCommandExecute){}
    }
}
