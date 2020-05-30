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
        ColorNew colorNew;
        public MainWindow()
        {
            InitializeComponent();
            listBox.ItemsSource = list;
        }
       
        //Змішування кольорів
        private void Change_Color(object sender, MouseEventArgs e)
        {
            byte aa = (byte)slAlpha.Value; //Retriving values from slider4
            byte rr = (byte)slRed.Value; //Retriving values from slider1
            byte gg = (byte)slGreen.Value; //Retriving values from slider2
            byte bb = (byte)slBlue.Value; //Retriving values from slider3
            
            Color cc = Color.FromArgb(aa, rr, gg, bb); //Create object of Color class.
            SolidColorBrush colorBrush = new SolidColorBrush(cc); //Creating object of SolidColorBruch class.
            tbFont.Background = colorBrush; //Setting background of stack panel.
            colorNew = new ColorNew { Name = tbFont.Background.ToString(), FontName = tbFont.Background.ToString() };

            //Перевірка включення кнопки Add
           
                bool checkExist = false;

                for (int i = 0; i < list.Count; i++)
                {
                    if (tbFont.Background.ToString() == list[i].FontName)
                    {
                        btAdd.IsEnabled = false;
                        checkExist = true;
                    }
                }

                if (!checkExist)
                    btAdd.IsEnabled = true;
     
        }

        //Add color in listBox
        private void Add_Color(object sender, RoutedEventArgs e)
        {
            list.Add(colorNew);
            btAdd.IsEnabled = false;

        }

        //Delete selected color from listBox
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please, select color!");
                return;
            }
           
          list.RemoveAt(listBox.SelectedIndex);
        }

       


    }
}
