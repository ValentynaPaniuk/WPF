using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
/*Необходимо разработать приложение «Клавиатурный тренажер» (рис. 1). 
Главное окно приложения должно отображать клавиатуру с не интерактивными клавишами, 
которые необходимо для того, чтобы помогать пользователю ориентироваться на клавиатуре, не смотря на нее. 
При этом при нажатии на каждую из клавиш она должна подсвечиваться на экране. 
После запуска тренировочной сессии пользователю должна отобразиться произвольно сгенерированная строка для ввода, 
которая учитывает выбранный уровень сложности. 
В верхней части окна должна отображаться статистическая информация: 
скорость набора корректного текста и количество допущенных ошибок. 
Также в верхней части окна должны располагаться элементы управления, 
позволяющие настроить сложность генерируемой строки для ввода. 
При помощи «ползунка» пользователь может выбрать количество символов, 
которые должны использоваться для генерируемой строки. 
В качестве используемых символов могут быть все символы, расположенные на рис.<br>
После нажатия на кнопку «Start» должна сгенерироваться строка символов с учетом заданных пользователем настроек. 
После этого нажимаемые пользователем клавиши должны учитываться и отображаться в виде введенных правильно символов
либо в виде ошибок.<br>
Также необходимо предусмотреть выключение тех элементов управления, 
которые не могут использоваться в текущем состоянии приложения. Например, 
нельзя нажимать кнопку «Stop», если пользователь перед этим не нажал кнопку «Start». 
Дополнительное задание (необязательное): При нажатии на клавиши Shift и Caps Lock, 
клавиатура в приложении должна менять отображаемые символы, с учетом реально вводимых. 
При этом в настройках должна быть возможность указать, необходимо ли генерировать строку с учетом регистра символов.*/

namespace KeyboardTrainer
{
    internal sealed partial class MainWindow : Window
    {
        int tempTimer = 0;
        int fails = 0;
        Random rendChar = new Random();
        string baceString = "QWERTYUIOPASDFGHJKLZXCVBNM~!@#$%^&*()_+{}|:\"<>?1234567890[],./\\`-=;'qwertyuiopasdfghjklzxcvbnm";
        bool flagCapsLock = true;
        bool flagBackspase = true;
        bool mesStop = true;
        DispatcherTimer timer = null;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }


        private void CapitalLetters()
        {
            this.Q.Text = "Q";
            this.W.Text = "W";
            this.E.Text = "E";
            this.R.Text = "R";
            this.T.Text = "T";
            this.Y.Text = "Y";
            this.U.Text = "U";
            this.I.Text = "I";
            this.O.Text = "O";
            this.P.Text = "P";
            this.A.Text = "A";
            this.S.Text = "S";
            this.D.Text = "D";
            this.F.Text = "F";
            this.G.Text = "G";
            this.H.Text = "H";
            this.J.Text = "J";
            this.K.Text = "K";
            this.L.Text = "L";
            this.Z.Text = "Z";
            this.X.Text = "X";
            this.C.Text = "C";
            this.V.Text = "V";
            this.B.Text = "B";
            this.N.Text = "N";
            this.M.Text = "M";

        }
        private void LoverLetters()
        {
            this.Q.Text = "q";
            this.W.Text = "w";
            this.E.Text = "e";
            this.R.Text = "r";
            this.T.Text = "t";
            this.Y.Text = "y";
            this.U.Text = "u";
            this.I.Text = "i";
            this.O.Text = "o";
            this.P.Text = "p";
            this.A.Text = "a";
            this.S.Text = "s";
            this.D.Text = "d";
            this.F.Text = "f";
            this.G.Text = "g";
            this.H.Text = "h";
            this.J.Text = "j";
            this.K.Text = "k";
            this.L.Text = "l";
            this.Z.Text = "z";
            this.X.Text = "x";
            this.C.Text = "c";
            this.V.Text = "v";
            this.B.Text = "b";
            this.N.Text = "n";
            this.M.Text = "m";

        }
        private void CapitalSymbol()
        {
            this.Oem3.Text = "~";
            this.D1.Text = "!";
            this.D2.Text = "@";
            this.D3.Text = "#";
            this.D4.Text = "$";
            this.D5.Text = "%";
            this.D6.Text = "^";
            this.D7.Text = "&";
            this.D8.Text = "*";
            this.D9.Text = "(";
            this.D0.Text = ")";
            this.OemMinus.Text = "_";
            this.OemPlus.Text = "+";
            this.OemOpenBrackets.Text = "{";
            this.Oem6.Text = "}";
            //this.Oem5.Text = "|";
            //this.Oem1.Content = ":";
            this.OemQuotes.Text = "\"";
            //this.OemComma.Content = "<";
            //this.OemPeriod.Content = ">";
            //this.OemQuestion.Content = "?";
        }
        private void LoverSymbol()
        {
            this.Oem3.Text = "`";
            this.X1.Text = "1";
            this.X2.Text = "2";
            this.X3.Text = "3";
            this.X4.Text = "4";
            this.X5.Text = "5";
            this.X6.Text = "6";
            this.X7.Text = "7";
            this.X8.Text = "8";
            this.X9.Text = "9";
            this.X0.Text = "0";
            this.OemMinus.Text = "-";
            this.OemPlus.Text = "=";
            this.OemOpenBrackets.Text = "[";
            this.Oem6.Text = "]";
            //this.Oem5.Content = "\\";
            this.Oem1.Text = ";";
            this.OemQuotes1.Text = "'";
            this.OemComma.Text = ",";
            this.OemPeriod.Text = ".";
            this.OemQuestion.Text = "/";
        }


        //Задаємо кількість символів, що будуть використовуватися для тренажера - від 1 до 10
        private void SlDifficulty_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int num = 0; 
            num = (int)SliderDifficulty.Value;
            Difficulty.Text = num.ToString();
        }

        //Вираховування швидкості
        private void Timer_Tick(object sender, EventArgs e)
        {
            tempTimer++;
            SpeedChar.Text = Math.Round(((double)lineUser.Text.Length / tempTimer) * 60).ToString();
        }

      

        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            foreach (UIElement it in (this.Content as Grid).Children)
            {
                if (it is Grid)
                {
                    foreach (var item in (it as Grid).Children)
                    {
                        if (item is TextBlock)
                        {
                            if ((item as TextBlock).Name == e.Key.ToString())
                            {
                                (item as TextBlock).Opacity = 0.5;
                                if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                {
                                    CapitalSymbol();
                                    if (flagCapsLock)
                                    {
                                        CapitalLetters();
                                    }
                                    else
                                    {
                                        LoverLetters();
                                    }
                                }
                                else if (e.Key.ToString() == "Capital")
                                {
                                    if (flagCapsLock)
                                    {
                                        CapitalLetters();
                                        flagCapsLock = false;
                                    }
                                    else
                                    {
                                        LoverLetters();
                                        flagCapsLock = true;
                                    }
                                }
                                else if (e.Key.ToString() == "Back")
                                {
                                    flagBackspase = false;
                                }
                                else
                                {
                                    flagBackspase = true;
                                }
                            }
                        }
                    }
                }
            }

        }

        //Вказуємо для слайда макс.кількість елементів коли від checked (94)
        private void CaseSensitive_Checked(object sender, RoutedEventArgs e)
        {
            SliderDifficulty.Maximum = 94;
        }
        //Вказуємо для слайда макс.кількість елементів коли від unchecked (47)
        private void CaseSensitive_Unchecked(object sender, RoutedEventArgs e)
        {
            SliderDifficulty.Maximum = 47;
        }

        //
        private void Window_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            lineUser.Focus();
            foreach (UIElement it in (this.Content as Grid).Children)
            {
                if (it is Grid)
                {
                    foreach (var item in (it as Grid).Children)
                    {
                        if (item is TextBlock)
                        {

                            if ((item as TextBlock).Name == e.Key.ToString())
                            {
                                (item as TextBlock).Opacity = 1;
                                if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                {
                                    LoverSymbol();
                                    if (!flagCapsLock)
                                    {
                                        CapitalLetters();
                                    }
                                    else
                                    {
                                        LoverLetters();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (!mesStop)
            {
                MessageBox.Show($"Задание завершенно!\n Количество символов {linePrograms.Text.Length}.\n Количество ошибок {Fails.Text}.\nДля завершения задания нажмите Stop.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                mesStop = true;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = false; //Неактивна кнопка
            SliderDifficulty.IsEnabled = false; //Неактивний слайд
            CaseSensitive.IsEnabled = false; //
            Stop.IsEnabled = true;
            tempTimer = 0;
            timer.Start();
            CollectString(Convert.ToInt32(Difficulty.Text), baceString, !(bool)CaseSensitive.IsChecked);
           // lineUser.IsReadOnly = false;
            lineUser.IsEnabled = true;
            lineUser.Focus();

        }

        private void CollectString(int countChar, string baceString, bool flagSensitive)
        {
            string carhs = "";
            int sensitive = (flagSensitive) ? 47 : 0;
           
            for (int i = 0; i < countChar; i++)
            {
                carhs += baceString[rendChar.Next(sensitive, baceString.Length)];
            }
            carhs += " ";
            int countString = (flagSensitive) ? 75 : 70;
            for (int i = 0; i < countString; i++)
            {
                linePrograms.Text += carhs[rendChar.Next(0, carhs.Length)];
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = true;
            SliderDifficulty.IsEnabled = true;
            CaseSensitive.IsEnabled = true;
            Stop.IsEnabled = false;
            lineUser.Text = "";
            linePrograms.Text = "";
            Fails.Text = "0";
            SpeedChar.Text = "0";
            Difficulty.Text = "0";
            lineUser.IsEnabled = false;
            timer.Stop();
            tempTimer = 0;
            fails = 0;
        }


        private void LineUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = linePrograms.Text.Substring(0, lineUser.Text.Length);
            if (lineUser.Text.Equals(str))
            {
                if (flagBackspase)
                {
                    SpeedChar.Text = Math.Round(((double)lineUser.Text.Length / tempTimer) * 60).ToString();
                }
                lineUser.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                if (flagBackspase)
                {
                    fails++;
                }
                lineUser.Foreground = new SolidColorBrush(Colors.Red);
                Fails.Text = fails.ToString();
            }
            if (lineUser.Text.Length == linePrograms.Text.Length)
            {
                timer.Stop();
                SpeedChar.Text = Math.Round(((double)lineUser.Text.Length / tempTimer) * 60).ToString();
                lineUser.IsReadOnly = true;
                mesStop = false;
            }
        }
    }
}