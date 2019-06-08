using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator
{

    public class CommandWithParameter : ICommand
    {
        Action<object> actionInvokedInView;
        public CommandWithParameter(Action<object> action)
        {
            actionInvokedInView = action;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            actionInvokedInView(parameter);
        }
    }
}
