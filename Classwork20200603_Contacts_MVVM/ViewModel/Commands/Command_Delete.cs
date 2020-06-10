using Classwork20200603_Contacts_MVVM.Mode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Classwork20200603_Contacts_MVVM.ViewModel.Commands
{



    public class Command_Delete : ICommand
    {
        public VM VM { get; set; }

        public Command_Delete(VM vm)
        {
            VM = vm;
        }
        public Command_Delete()
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
            //if (parameter != null)
            //    return !String.IsNullOrEmpty((parameter as Contact).Phone);
            return true;
        }

        public void Execute(object parameter)
        {
            int phoneParameter = (int)parameter; 
            VM.DeleteContact(phoneParameter);
        }
    }
}
