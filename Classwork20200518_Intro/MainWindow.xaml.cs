using System;
using System.Collections.Generic;
using System.Drawing;
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


namespace Classwork20200518_Intro
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            ChangeForegroundColor();
        }

        public void ChangeForegroundColor()
        {
           String [] colors = typeof(System.Drawing.Color).GetProperties().Select(x => x.Name).ToArray();

           foreach (Button item in WP1.Children)
           {
                        //  item.Foreground = new SolidColorBrush(Colors.Red);
                       
                         var color = new BrushConverter().ConvertFromString(item.Content.ToString());
                        item.Foreground = (SolidColorBrush)color;
                    
                
           }

        }

     }
}
