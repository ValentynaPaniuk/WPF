using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Classwork20200527_ColorRGB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ColorNew> list = new ObservableCollection<ColorNew>();
        public MainWindow()
        {
            InitializeComponent();
            listBox.ItemsSource = list;

           


        }

        ColorNew colorNew;
        private void Change_Color(object sender, MouseEventArgs e)
        {
           
            byte aa = (byte)slAlpha.Value; //Retriving values from slider3
            byte rr = (byte)slRed.Value; //Retriving values from slider1
            byte gg = (byte)slGreen.Value; //Retriving values from slider2
            byte bb = (byte)slBlue.Value; //Retriving values from slider3
            
            Color cc = Color.FromArgb(aa, rr, gg, bb); //Create object of Color class.
            SolidColorBrush colorBrush = new SolidColorBrush(cc); //Creating object of SolidColorBruch class.
            tbFont.Background = colorBrush; //Setting background of stack panel.
            colorNew = new ColorNew { Name = colorBrush.ToString(), FontName = tbFont.Background.ToString() };


        }

        private void Add_Color(object sender, RoutedEventArgs e)
        {
            
            list.Add(colorNew);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            list.Remove(colorNew);
        }

     

        //if (cb1.IsChecked == true)
        //    {
        //        slAlpha.IsEnabled = false;
        //    }
        //    if (cb2.IsChecked == true)
        //    {
        //        slRed.IsEnabled = false;
        //    }
        //    if (cb3.IsChecked == true)
        //    {
        //        slGreen.IsEnabled = false;
        //    }
        //    if (cb4.IsChecked == true)
        //    {
        //        slBlue.IsEnabled = false;
        //    }

    }
}
