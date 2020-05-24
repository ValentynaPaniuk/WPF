using Microsoft.Win32;
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
using System.Windows.Threading;

namespace Classwork20200521_MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public MainWindow()
        {
            InitializeComponent();

        }

        private void openSoundButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
          
            if (of.ShowDialog() == true)
            {
                foreach (String file in of.FileNames)
                {
                    try
                    {
                        myMediaElement.Source = new Uri(of.FileName);
                        listBox1.Items.Add(of.FileName.ToString());
                    

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            
        }

        private void playSoundButton_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Play();
        }

        private void stopSoundButton_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Stop();
        }

        private void plusSoundButton_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Volume += 0.1;
        }

        private void minusSoundButton_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Volume -= 0.1;
        }

        private void muteSoundButton_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Volume = 0;
        }

        private void SlTime_LostMouseCapture(object sender, MouseEventArgs e) //реализум возможность перемотки видео/аудио трека перетаскиванием ползунка слайдера. Срабатывает на момент отпускания клавиши мышки
        {
            TimeSpan time = new TimeSpan(0, 0, Convert.ToInt32(Math.Round(SlTime.Value))); //отлавливаем позицию на которую нужно перемотать трек
            textBox1.Text = time.ToString();
            myMediaElement.Position = time; //устанавливаем новую позицию для трека
        }

        private void MyMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            SlTime.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalSeconds; //устанавливаем максимальное значение для слайдера отвечающего за длинну проигрываемого ролика
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            this.Height = 500;
        }

        private void pauseSoundButton_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Pause();
        }

      
    }
}
