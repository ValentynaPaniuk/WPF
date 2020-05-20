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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Classwork20200520_Window
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Customer> customers { get; set; } = new List<Customer>();
        public MainWindow()
        {
            InitializeComponent();

            //Додаємо в ComboBox юзерів
            CbCustomer.Items.Add("Admin");
            CbCustomer.Items.Add("User");

            LoadCustomers();
        }

        //Зберігаємо дані в ListBox з текстових полів і додаємо значення в customers(List)
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(CbCustomer.Text) &&
                !String.IsNullOrWhiteSpace(TbName.Text) &&
                !String.IsNullOrWhiteSpace(TbLastName.Text) &&
                !String.IsNullOrWhiteSpace(TbEmail.Text))
            {
                Customer customer = new Customer
                {
                    Type = CbCustomer.Text,
                    Name = TbName.Text,
                    LName = TbLastName.Text,
                    Email = TbEmail.Text
                };

                customers.Add(customer);
                LbCustomers.Items.Add(customer);

                CbCustomer.Text = TbName.Text = TbLastName.Text = TbEmail.Text = "";
            }
        }

        //Загружаємо дані в ListBox (десеріалізвція)
        private void LoadCustomers()
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Customer>));
                string file = "Customers.xml";
                using (Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    customers = (List<Customer>)xml.Deserialize(stream);
                //foreach (Customer item in customers)
                //    lbCustomers.Items.Add(item);

                LbCustomers.ItemsSource = customers;
                LbCustomers.DisplayMemberPath = "FirstName";
            }
            catch { }
        }

        //Серіалізуємо файл в XML
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string file = "Сustomers.xml";
            XmlSerializer xml = new XmlSerializer(customers.GetType());
            using (Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                xml.Serialize(stream, customers);
            }
        }


    }
}
