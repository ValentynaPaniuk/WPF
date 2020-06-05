using Classwork20200603_Contacts_MVVM.Mode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Classwork20200603_Contacts_MVVM.ViewModel.Commands
{
    public class Command_Cleare : ICommand
    {
        public VM VM { get; set; }

        public Command_Cleare(VM vm)
        {
            VM = vm;
        }
        public Command_Cleare()
        {

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
            if (parameter != null)
                return !String.IsNullOrEmpty((parameter as Contact).Name);
            return true;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            VM.CleareContact();
        }
    }
}
