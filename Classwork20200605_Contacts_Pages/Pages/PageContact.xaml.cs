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

namespace Classwork20200605_Contacts_Pages.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageContact.xaml
    /// </summary>
    public partial class PageContact : Page
    {
        public List<Contact> Contacts { get; set; } = new List<Contact>()
        {
            new Contact{ Name="Ania", Surname="Grynchuk", Age=19},
            new Contact{ Name="Tania", Surname="Kovalchuk", Age=18},
            new Contact{ Name="Ira", Surname="Shapran", Age=21}

        };

        public PageContact()
        {
            InitializeComponent();
            lbContact.DataContext = Contacts; //На DataContext призначаємо контакти
        }
    }
}
