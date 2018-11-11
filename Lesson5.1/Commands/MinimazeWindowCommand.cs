using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lesson5._1.Commands
{
    class MinimazeWindowCommand : LambdaCommand
    {
        public MinimazeWindowCommand() : base(p => ((Window)p).WindowState = WindowState.Minimized, p => p is Window) { }
    }
}
