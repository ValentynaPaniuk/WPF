using Classwork20200601_MVVM.Mode;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

/* 1. Registration in site and create API (API Key)
       xuZDPJMha3wTKgqrWD1r6BzZlGI5AlTM - API Key in SITE:  https:/developer.accuweather.com/user/me/apps
    2. API Reference - методи для отримання даних з серверу
      2.1. Locations API -> Autocomplete search - повертає місце локації в textBox. Робимо запит
      2.2. Current Conditions API -> вказуємо ID міста. Робимо запит.
    3. Створюємо папку Mode в проекті і створюємо два класи: City, CurrentConditions
    4. Копіюємо один елемент з Current Conditions API і вставляємо через Правка - Специальная вставка - Вставка через Json-клас
                                                                         Edit - Paste Special - Paste JSON as classed 
      в клас CurrentConditions
    5. Класи зробити public.
    6. Повторюємо пункт 4 з Location API і заповнюємо клас City
    7. Створюємо папку ViewModel і в ній 
                       папку Helpers і в ній 
                       клас AccuWeatherHelper (PUBLIC зробити)
    8. Створюємо поля відповідні в класі AccuWeatherHelper
       з ссилок на посилання в інтернеті
    9. Подальші дії описані в класі AccuWeatherHelper*/




namespace Classwork20200601_MVVM.ViewModel.Helpers
{
    
    public class AccuWeatherHelper
    {
        //dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=xuZDPJMha3wTKgqrWD1r6BzZlGI5AlTM&q=Rivne    //Ссилка на міста в закладці cURL
        //dataservice.accuweather.com/currentconditions/v1/325590?apikey=xuZDPJMha3wTKgqrWD1r6BzZlGI5AlTM                 //Ссилка на погоду в закладці cURL
        public const string BASE_URL = "http://dataservice.accuweather.com/"; // Спільна адреса на обидві ссилки
        public const string API_KEY = "xuZDPJMha3wTKgqrWD1r6BzZlGI5AlTM"; //Вставити свій API код
        public const string AUTOCOMPLETE_ANDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}"; // AndPoint Витираємо спільний код apikey і створюємо поле API_KEY
        public const string CURRENTCONDITIONS_ANDPOINT = "currentconditions/v1/{0}?apikey={1}"; //Витираємо спільний код apikey і створюємо поле API_KEY


        //Метод для отримання даних міста по запиту
        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new List<City>();

            // Створюємо ссилку на яку будемо ходити
            string url = BASE_URL + String.Format(AUTOCOMPLETE_ANDPOINT, API_KEY, query);

            //Клас, що дозволяє сходити по url і забрати з нього дані
            using (HttpClient client = new HttpClient())
            {
               //Ходимо на сайті і шукаємо дані RESPONCE
               var responce = await client.GetAsync(url);
                string json = await responce.Content.ReadAsStringAsync(); // отримуємо дані у вигляді json
                //Ставимо Newtonsoft.json
               cities =  JsonConvert.DeserializeObject<List<City>>(json); //Розпарсимо рядок json в об'єкт List<City>
            }


            return cities;
        }

        //Метод для отримання даних про погоду
        public static async Task<CurrentConditions> GetCurrentConditions( string locationKey)
        {
            CurrentConditions currentConditions = new CurrentConditions();
            string url = BASE_URL + String.Format(CURRENTCONDITIONS_ANDPOINT, locationKey, API_KEY);
            //Клас, що дозволяє сходити по url і забрати з нього дані
            using (HttpClient client = new HttpClient())
            {
                //Ходимо на сайті і шукаємо дані RESPONCE
                var responce = await client.GetAsync(url);
                string json = await responce.Content.ReadAsStringAsync(); // отримуємо дані у вигляді json
                                                                          //Ставимо Newtonsoft.json
                currentConditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(json)[0]; //Розпарсимо рядок json в об'єкт List<CurrentConditions>
            }
            return currentConditions;
        }



        /*
         10. Видаляємо MainWindow
         11. Створюємо папку View
         12. В ній створюємо вікно WeatherWindow
         13. Розміщуємо всі елементи на вікні, що нам потрібні в XAML
         14. Створюємо клас WeatherVM в папці ViewModel
         15. Створюємо поля для нього і методи
         16. Прив'язуємо об'єкт класу WeatherVM через Window.Resource (перед тим підключаємо простір імен з WeatherVM -  xmlns:vm="clr-namespace:Classwork20200601_MVVM.ViewModel")
         17. Підключаємо  в Grid <Grid DataContext="{StaticResource vm}"> і підключаємо Binding для TextBox, де будемо вводити місто і 
         18. Міняємо назву вікна MainWindow в App.xaml( StartupUri="View/WeatherWindow.xaml">) і App.g.i.cs(this.StartupUri = new System.Uri("View/WeatherWindow.xaml", System.UriKind.Relative);)
         */

    }
}
