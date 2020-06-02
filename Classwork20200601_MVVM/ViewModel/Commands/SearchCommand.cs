using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Classwork20200601_MVVM.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        WeatherVM VM { get; set; }

        public SearchCommand(WeatherVM vm)
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

        //Перевірка можливості натискання кнопки - чи є щось в textBox(Guery)
        public bool CanExecute(object parameter)
        {
            return !String.IsNullOrEmpty(parameter as string);
        }

        //Робимо запит на міста
        public void Execute(object parameter)
        {
            VM.MakeRequestCities();
        }
    }
}
