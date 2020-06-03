using Classwork20200601_MVVM.Mode;
using Classwork20200601_MVVM.ViewModel.Commands;
using Classwork20200601_MVVM.ViewModel.Converters;
using Classwork20200601_MVVM.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

//Проміжний рівень між вікном і нашими даними в Mode
namespace Classwork20200601_MVVM.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {


        public ObservableCollection<City> Cities { get; set; } = new ObservableCollection<City>();
        public SearchCommand SearchCommand { get; set; }
        public OpenHttpLinkCommand OpenHttpLinkCommand { get; set; }

        private string query; //Text in textBox

        //Малюнок
        private string imgUrl;
        public string ImgUrl
        {
            get => imgUrl;
            set
            {
                imgUrl = value;
                OnNotify();
            }
        }

        //Рядок міста
        public string Query
        {
            get => query;
            set
            {
                query = value;
                OnNotify();
            }
        }

       
        //Погода
        private CurrentConditions currentConditions;
        public CurrentConditions CurrentConditions
        {
            get => currentConditions;
            set
            {
               
                    currentConditions = value;
                    OnNotify();
                
            }
        }
        
        private City selectedCity;
        public City SelectedCity
        {
            get => selectedCity;
            set
            {
                selectedCity = value;
                GetConditions();
                OnNotify();
            }
        }

        //Конструктор
        public WeatherVM()
        {
            SearchCommand = new SearchCommand(this);
            Query = "";
            OpenHttpLinkCommand = new OpenHttpLinkCommand(this);

        }

      

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        //Буде робитися запит по містах
        public async void MakeRequestCities()
        {
            Cities.Clear();
          var temp = await  AccuWeatherHelper.GetCities(Query);
            foreach (var item in temp)
            {
                Cities.Add(item);//Записуємо дані в ObservableCollection<City> Cities
            }
        }

        //Буде робити запит по погоді
        private async void GetConditions()
        {
            if (SelectedCity != null)
            {
                CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
                ImgUrl = $"../img/{CurrentConditions.WeatherIcon}.png";

            }
            else
            {
                CurrentConditions = new CurrentConditions();
            }
        }

        //Open httpLink
        public void OnOpenHttpLinkCommand()
        {
            try
            {
                System.Diagnostics.Process.Start(CurrentConditions.Link);
            }
            catch (Exception)
            {

            }
        }


    }
}
