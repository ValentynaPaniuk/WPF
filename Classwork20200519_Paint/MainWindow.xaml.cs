using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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



/*Paint:
Режими малювання RadioButtons
combobox для вибору ширини ліній
combobox для вибору кольору
Кнопка "Очистити все"
кнопки зберегти\
відкрити - реалізація за допомогою діалогових вікон*/

namespace Classwork20200519_Paint
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       String[] colors = typeof(System.Drawing.Color).GetProperties().Select(x => x.Name).ToArray();
        public MainWindow()
        {
            InitializeComponent();
            ink.DefaultDrawingAttributes.Color = Colors.Red;
            ink.DefaultDrawingAttributes.Width = 10;
            ink.DefaultDrawingAttributes.Height = 10;

            //Додаємо в ComboBox Size
            for (int i = 8; i < 72; i += 2) { cbSize.Items.Add(i); }
            cbSize.SelectedIndex = new Random().Next(0, cbSize.Items.Count);

            //  //Додаємо в ComboBox Colors
            for (int i = 0; i < colors.Length; i++)
            {
                cbColor.Items.Add(colors[i]);
            }
            for (int i = 0; i < 9; i++)
            {
                cbColor.Items.RemoveAt(cbColor.Items.Count - 1);
            }
            cbColor.Items.RemoveAt(0);
            cbColor.SelectedIndex = new Random().Next(0, cbColor.Items.Count);


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

     
       

        //Збереження малюнку
        private void save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "str files|*.str";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.FileName = "Picture";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == true)
            {
                ink.Strokes.Save(new FileStream(saveFileDialog1.FileName, FileMode.Create));
            }
          
        }

        //Відкриття малюнку
        private void open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                //InitialDirectory = @"D:\",
                Title = "Browse Text Files",
                //CheckFileExists = true,
               // CheckPathExists = true,
               // DefaultExt = "str",
                Filter = "STR-files|*.str",
               // FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true,
                FileName = "Type name here"
            };

            if (openFileDialog1.ShowDialog() == true)
            {
                StrokeCollection strokes = new StrokeCollection(new FileStream(openFileDialog1.FileName, FileMode.Open));
                ink.Strokes = strokes;
            }
           
        }

       //Зміна розміру шрифта
        private void CbSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Size = Convert.ToDouble(cbSize.SelectedItem);
            ink.DefaultDrawingAttributes.Width = ink.DefaultDrawingAttributes.Height = Size;
        }

        //Зміна кольору
        private void CbColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string color = cbColor.SelectedItem.ToString();
            ink.DefaultDrawingAttributes.Color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(color);

        }

        //Очистити все
        private void Clear(object sender, RoutedEventArgs e)
        {
            ink.Children.Clear();
            //cbColor.SelectedItem = ink.DefaultDrawingAttributes.Color.ToString();
            //ink.DefaultDrawingAttributes.Color = Colors.Black;
            //ink.Background = System.Windows.Media.Brushes.White;
            ink.Strokes.Clear();
          
            

        }
    }
}
