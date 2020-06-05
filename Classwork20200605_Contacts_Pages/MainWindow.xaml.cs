using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Classwork20200605_Contacts_Pages
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Prop();
           
        }

        private void ChoosePage_Click(object sender, RoutedEventArgs e)
        {
           (DataContext as Prop).PathPage = (e.Source as Button).Tag.ToString();
        }



    }

    public class Prop : INotifyPropertyChanged
    {
        private string path;
        //prop
        //propfull
        public string PathPage
        {
            get { return path; }
            set
            {
                path = value;
                OnNotify();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotify([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
