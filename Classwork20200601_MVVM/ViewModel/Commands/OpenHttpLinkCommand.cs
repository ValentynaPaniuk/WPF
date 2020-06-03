using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Classwork20200601_MVVM.ViewModel.Commands
{
    public class OpenHttpLinkCommand : ICommand
    {
        WeatherVM VM { get; set; }

        public OpenHttpLinkCommand(WeatherVM vm)
        {
            VM = vm;
        }


        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return !String.IsNullOrEmpty(parameter as string);
        }

        public void Execute(object parameter)
        {
            VM.OnOpenHttpLinkCommand();
        }
    }
}
