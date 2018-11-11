using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lesson5._1.Commands
{
    class CloseWindowCommand : LambdaCommand
    {
        public CloseWindowCommand() : base(p => ((Window)p).Close(), p => p is Window) { }
    }
}
