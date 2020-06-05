using Classwork20200603_Contacts_MVVM.Mode;
using System;
using System.Windows.Input;

namespace Classwork20200603_Contacts_MVVM.ViewModel.Commands
{
    public class Command_Add : ICommand
    {

       public VM VM { get; set; }

        public Command_Add(VM vm)
        {
            VM = vm;
        }

        public Command_Add()
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
            VM.AddContacts();
        }
    }
}
