using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Classwork20200519_Paint
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ink.DefaultDrawingAttributes.Color = Colors.Red;
            ink.DefaultDrawingAttributes.Width = 10;

            
          

        }

        //Видалення рядком
        private void eraseByStrokeEditingMode_Click(object sender, RoutedEventArgs e)
        {
            ink.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }
        //Видалення поточечно
        private void eraseByPointEditingMode_Click(object sender, RoutedEventArgs e)
        {
            ink.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        //Події курсору спрацьовують, а чорнило завжди видаляється.
        private void drawingThenErasing_Click(object sender, RoutedEventArgs e)
        {
            ink.EditingMode = InkCanvasEditingMode.GestureOnly;
        }
        //
        private void drawing_Click(object sender, RoutedEventArgs e)
        {
            ink.EditingMode = InkCanvasEditingMode.Ink;
        }

        //Зміна кольору 
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string color = (cbColor.SelectedItem as Label).Content.ToString();
            
            ink.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(color);
        }
        //Збереження малюнку
        private void save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "str files|*.str";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == true)
            {
                ink.Strokes.Save(new FileStream("1.str", FileMode.Create));
            }
            else
            {
                MessageBox.Show("!!!!!!!!!");
            }
        }

        //Відкриття малюнку
        private void open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|STR-files|*.str",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == true)
            {
                StrokeCollection strokes = new StrokeCollection(new FileStream("1.str", FileMode.Open));
                ink.Strokes = strokes;
            }
            else
            {
                MessageBox.Show("???????");
            }
        }

       
    }
}
