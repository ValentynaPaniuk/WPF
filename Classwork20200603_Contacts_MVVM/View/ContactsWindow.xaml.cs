using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Classwork20200603_Contacts_MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для ContactsWindow.xaml
    /// </summary>
    public partial class ContactsWindow : Window
    {
        public ContactsWindow()
        {
            InitializeComponent();
        }

        private void Lang_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("Properties/" + (sender as MenuItem).Tag + ".xaml", UriKind.Relative);

            // доступаюсь до батькывського пункта меню
            MenuItem header = (sender as MenuItem).Parent as MenuItem;
            // перебираю всі підпункти в пункті Мова
            foreach (var item in header.Items)
            {
                // знімаю галочки з усіх пунктів
                (item as MenuItem).IsChecked = false;
            }
            // встановлюю галочку тільки в того пункта, по якому клікнула
             (sender as MenuItem).IsChecked = !(sender as MenuItem).IsChecked;

            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(dictionary);
        }




        string[] themesArr = { "light", "dark" };
        int i = 0;
        private void ChangeThemes(int index)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("themes/" + themesArr[index] + ".xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(dictionary);
        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as MenuItem).Tag);
            ChangeThemes(index);
        }


    }
}
