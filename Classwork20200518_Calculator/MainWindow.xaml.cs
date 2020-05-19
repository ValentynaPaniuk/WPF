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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Classwork20200518_Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double x = 0;
        double y = 0;
        double z = 0;
        string znak = "+";

        public MainWindow()
        {
            InitializeComponent();
        }
        //Вводимо перше число в TextBox
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text.Length == 1 && textBox1.Text == "0" && (sender as Button).Content.ToString() == ",")
            {
                textBox1.Text += ",";
            }

            ////Перевірка на кількість ком
            if (textBox1.Text.Contains(",") && (sender as Button).Content.ToString() == ",")
                return;

            if (textBox1.Text == "0" && textBox1.Text != null && textBox1.Text.Length == 1)
            {
                textBox1.Text = textBox1.Text.Remove(0, 1);
                textBox1.Text += (sender as Button).Content.ToString();
            }
            else
            {
                textBox1.Text = textBox1.Text + (sender as Button).Content;
            }
          
        }

        private void BtnEquel_Click(object sender, RoutedEventArgs e)
        {

            y = Convert.ToDouble(textBox1.Text);
            label1.Content = x.ToString() + znak + y;

            switch (znak)
            {
                case "+":
                    {
                        z = x + y;
                        label1.Content = x.ToString() + znak + y.ToString() + " = " + z.ToString();
                        break;
                    }
                case "-":
                    {
                        z = x - y;
                        label1.Content = x.ToString() + znak + y.ToString() + " = " + z.ToString();
                        break;
                    }
                case "*":
                    {
                        z = x * y;
                        label1.Content = x.ToString() + znak + y.ToString() + " = " + z.ToString();
                        break;
                    }
                case "/":
                    {
                        if (y == 0)
                        {
                            MessageBox.Show("It is not possible to divide by zero");
                        }
                        z = x / y;
                        label1.Content = x.ToString() + znak + y.ToString() + " = " + z.ToString();
                        break;
                    }

            }
            textBox1.Text = z.ToString();
        }

        //Записуємо число в змінну Х і записуємо дію в znak 
        private void BtnDiv_Click(object sender, RoutedEventArgs e)
        {
            x = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();

            znak = (sender as Button).Content.ToString(); 
            label1.Content = x.ToString() + znak;
            textBox1.Clear();
        }

        //Видалення останнього символу
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);//Видалення останнього символу
            label1.Content = textBox1.Text;
        }

        //Видаляємо все в textBox1
        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "0";
            label1.Content = String.Empty;
            textBox1.Focus();
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
                if (textBox1.Text[0] == '-')
                    textBox1.Text = textBox1.Text.Remove(0, 1); // видаляється перший символ
                else textBox1.Text = '-' + textBox1.Text;

            label1.Content = textBox1.Text;
        }
    }
}
