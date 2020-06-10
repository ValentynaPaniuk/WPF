using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Classwork20200608_Registration_Trigger.ViewMode.Command
{
    public class Command_Registration : ICommand
    {
      public  UserVM VM { get; set; }

        public Command_Registration(UserVM vm)
        {
            VM = vm;
        }

        //Модель підписки на події
        
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

        //Перевірка можливості натискання кнопки - чи є щось в textBox()
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.AddUsers();
        }
    }
}
